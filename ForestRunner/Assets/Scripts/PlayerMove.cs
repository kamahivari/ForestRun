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
        transform.Translate(Vector3.forward * Time.deltaTime * ileriHiz,Space.World);     //Zamana bagli vector3 �zerinden hareket ; Space.World=0 Default koordinat d�zleminde hareket.
        
        if ((Input.GetKey(KeyCode.A)) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > LevelSinir.solTrf)       //levelsinirlari i�erisinde kalmak �art�yla
            {
                transform.Translate(Vector3.left * Time.deltaTime * solsagHiz);
            }

        }

        if ((Input.GetKey(KeyCode.D)) || Input.GetKey(KeyCode.RightArrow))
        {

            if (this.gameObject.transform.position.x < LevelSinir.sagTrf)
            {
                transform.Translate(Vector3.left * Time.deltaTime * solsagHiz * -1);  //Tek de�i�ken �zerinde sola-saga ivmelenmenin axiste ters y�ne i�aret etmesi i�in -1
            }
        }


    }

    private void OnTriggerEnter(Collider other)                    //SpawnManager-ZeminSpawner;3.ad�m -> Player Collider'a girince tetiklenerek s�radaki zemini olu�turuyor.
    {
        spawnManager.SpawnTriggerGiris();  // Collidera giri�te tetiklenecek func. 
    }

}
