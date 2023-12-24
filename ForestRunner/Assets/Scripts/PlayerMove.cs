using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{


    public float ileriHiz = 3;
    public float solsagHiz = 4;

    public bool zipliyorMu = false;  //default  -->> Zýplama 2 aþamalý ; yükselme ve düsme
    public bool dusuyorMu = false;
    public GameObject playerObject;

    //------------------------------------------------------------------------------------------------->Ýnscpector pencerisinden müdahale edilebilecek satýrlar
                   
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



            if ((Input.GetKey(KeyCode.W)) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
            {
                if (zipliyorMu == false)
                {
                    zipliyorMu = true;
                    playerObject.GetComponent<Animator>().Play("Jumping"); //Animator penceresine referans vererek "Jumping" animasyonunu çaðýr

               
                    StartCoroutine(ZiplamaSirasi()); // Coroutine çaliþtirarak belli bir süreyle tekrar tekrar çalýþabilecek bir yapi saglanir

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
        float ilkYukseklik = transform.position.y; //ilk yuksekligi almadýðýmýzda karaktere ardarda zýpla komutu verince gerçek y ekseni koordinatý bozuluyor
        yield return new WaitForSeconds(ziplamaAraligi);
        dusuyorMu = true;
        yield return new WaitForSeconds(ziplamaAraligi);         //belli bir süre beklemesini saðlayabiliriz zýplamasý için
        zipliyorMu = false;
        dusuyorMu = false;
        playerObject.GetComponent<Animator>().Play("Standard Run");  //Surekli kosmasý gerektiði için Looptaki koþma animasyonu tekrar çaðrýlmalý
        transform.position = new Vector3(transform.position.x, ilkYukseklik, transform.position.z);
    }



 
    private void OnTriggerEnter(Collider other)                    //SpawnManager-ZeminSpawner;3.adým -> Player Collider'a girince tetiklenerek sýradaki zemini oluþturuyor.
    {  
        spawnManager.SpawnTriggerGiris();  // Collidera giriþte tetiklenecek func. 

    }
    

}
