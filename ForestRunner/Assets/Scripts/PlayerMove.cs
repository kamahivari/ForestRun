using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{


    public float ileriHiz= 3;
    public float solsagHiz = 4;

    public SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * ileriHiz,Space.World);     //Zamana bagli vector3 üzerinden hareket ; Space.World=0 Default koordinat düzleminde hareket.
        
        if ((Input.GetKey(KeyCode.A)) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > LevelSinir.solTrf)       //levelsinirlari içerisinde kalmak þartýyla
            {
                transform.Translate(Vector3.left * Time.deltaTime * solsagHiz);
            }

        }

        if ((Input.GetKey(KeyCode.D)) || Input.GetKey(KeyCode.RightArrow))
        {

            if (this.gameObject.transform.position.x < LevelSinir.sagTrf)
            {
                transform.Translate(Vector3.left * Time.deltaTime * solsagHiz * -1);  //Tek deðiþken üzerinde sola-saga ivmelenmenin axiste ters yöne iþaret etmesi için -1
            }
        }


    }

    private void OnTriggerEnter(Collider other)                    //SpawnManager-ZeminSpawner;3.adým -> Player Collider'a girince tetiklenerek sýradaki zemini oluþturuyor.
    {
        spawnManager.SpawnTriggerGiris();  // Collidera giriþte tetiklenecek func. 
    }

}
