using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSpawner : MonoBehaviour
{
    [SerializeField]
    Transform ParentObject;
    public GameObject[] barriers;
    public int a = 0;

    void Start()
    {
       
        // Rastgele bir indeks seç
        int barrierIndex = Random.Range(0, barriers.Length);
        float z = 30;
        float x = 0;
       
        
       
        
        StartCoroutine(SpawnObjectCoroutine());
        StartCoroutine(DestroyObjectCoroutine());


        IEnumerator SpawnObjectCoroutine()
        {
            while (true)
            {
                Vector3 position = new Vector3(x, 0.5f, z);
                GameObject selectedObject = Instantiate(barriers[barrierIndex], position, Quaternion.identity, transform);
                barrierIndex = Random.Range(0, barriers.Length);
                z += Random.Range(6, 25); //ENGELLERIN MESAFESI RASGELE olarak burada belirleniyor
                x = Random.Range(-2.5f, 2.5f); //Yatayda konumu
                
                yield return new WaitForSeconds(1.5f); // 5 saniye bekle
            }
        }
        IEnumerator DestroyObjectCoroutine()
        {
            while (true)
            {
                    Transform child = ParentObject.GetChild(a);
                    yield return new WaitForSeconds(10f);

                    // 10 saniyede bir burada objecti siliyoruz optimizasyon icin.
                    Destroy(child.gameObject);
                     a++;
                }


            }

        }
    }

