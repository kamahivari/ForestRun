using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{


    public float ileriHiz = 3;
    public float solsagHiz = 4;

    public bool zipliyorMu = false;  //default  -->> Z�plama 2 a�amal� ; y�kselme ve d�sme
    public bool dusuyorMu = false;
    public GameObject playerObject;

    //------------------------------------------------------------------------------------------------->�nscpector pencerisinden m�dahale edilebilecek sat�rlar
                   
    [SerializeField] float ziplamaKuvveti = 3f;
    [SerializeField] float ziplamaAraligi = 0.45f;
    

    [SerializeField] Rigidbody rb;

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



            if ((Input.GetKey(KeyCode.W)) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
            {
                if (zipliyorMu == false)
                {
                    zipliyorMu = true;
                    playerObject.GetComponent<Animator>().Play("Jumping"); //Animator penceresine referans vererek "Jumping" animasyonunu �a��r

               
                    StartCoroutine(ZiplamaSirasi()); // Coroutine �ali�tirarak belli bir s�reyle tekrar tekrar �al��abilecek bir yapi saglanir

                }
            }

      





        if (zipliyorMu==true)
            {
                if(dusuyorMu==false)
                {
                    transform.Translate(Vector3.up * Time.deltaTime * ziplamaKuvveti, Space.World);
                }

                if(dusuyorMu==true)
                {
                   transform.Translate(Vector3.up * Time.deltaTime * -ziplamaKuvveti, Space.World);
                }

            }

       




    }



    IEnumerator ZiplamaSirasi()
    {
        float ilkYukseklik = transform.position.y; //ilk yuksekligi almad���m�zda karaktere ardarda z�pla komutu verince ger�ek y ekseni koordinat� bozuluyor
        yield return new WaitForSeconds(ziplamaAraligi);
        dusuyorMu = true;
        yield return new WaitForSeconds(ziplamaAraligi);         //belli bir s�re beklemesini sa�layabiliriz z�plamas� i�in
        zipliyorMu = false;
        dusuyorMu = false;
        playerObject.GetComponent<Animator>().Play("Standard Run");  //Surekli kosmas� gerekti�i i�in Looptaki ko�ma animasyonu tekrar �a�r�lmal�
        transform.position = new Vector3(transform.position.x, ilkYukseklik, transform.position.z);
    }



 
    private void OnTriggerEnter(Collider other)                    //SpawnManager-ZeminSpawner;3.ad�m -> Player Collider'a girince tetiklenerek s�radaki zemini olu�turuyor.
    {  
        spawnManager.SpawnTriggerGiris();  // Collidera giri�te tetiklenecek func. 

    }
    

}
