using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngelSpawner : MonoBehaviour
{

    public GameObject[] engelPreb;
    public float zSpawn = 15;
    public float engelAralik = 12;
    public int engelSayi = 5;

    private List<GameObject> aktifEngel = new List<GameObject>();
    public Transform playerTransform;


    // Start is called before the first frame update
    void Start()
    {
     for(int i = 0; i < engelSayi;i++)
        {
            if (i == 0)
                SpawnEngel(0);
            else
                SpawnEngel(Random.Range(0, engelPreb.Length));
        }   
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - 35 > zSpawn - (engelSayi * engelAralik))
        {
            SpawnEngel(Random.Range(0, engelPreb.Length));
            DeleteEngel();
        }
        
    }


    public void SpawnEngel(int engelIndex)
    {
        GameObject aktif = Instantiate(engelPreb[engelIndex], transform.forward * zSpawn, transform.rotation);
        aktifEngel.Add(aktif);
        zSpawn += engelAralik;

    }
    
    private void DeleteEngel()
    {
        Destroy(aktifEngel[0]);
        aktifEngel.RemoveAt(0);
    }
}
