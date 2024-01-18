using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{

    public static bool isAlive=true; //Karekter hayattamý
    public float ileriHiz = 3;
    public float solsagHiz = 4;

    public bool zipliyorMu = false;  //default  -->> Zýplama 2 aþamalý ; yükselme ve düsme
    public bool dusuyorMu = false;

 
    public GameObject playerObject;

    public GameManager gameManager;
   
    //------------------------------------------------------------------------------------------------->Ýnscpector pencerisinden müdahale edilebilecek satýrlar
                   
    [SerializeField] float ziplamaKuvveti = 3f;
    [SerializeField] float ziplamaAraligi = 0.45f;
    [SerializeField] Animator animator;
    [SerializeField] GameObject deathPanel;
    



    [SerializeField] Rigidbody rb;

    public SpawnManager spawnManager;


 
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("hizArtis", 30f,30f); // Belirli bir zaman aralýðýnda uyandýrýlacak fonksiyon ; 30sn sonra ilk uyandýrma - 30sn araliklarla ;; 
                                                // Level Scaling ve Zorluk aþamasý için modifiye edilebilir - geliþtirilebilir.
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isAlive)
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

                animator.SetTrigger("jump");//Jump Animasyonunu Tetikle

                StartCoroutine(ZiplamaSirasi()); // Coroutine çaliþtirarak belli bir süreyle tekrar tekrar çalýþabilecek bir yapi saglanir

                }
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
        
        transform.position = new Vector3(transform.position.x, ilkYukseklik, transform.position.z);
    }



 
    private void OnTriggerEnter(Collider other)                    //SpawnManager-ZeminSpawner;3.adým -> Player Collider'a girince tetiklenerek sýradaki zemini oluþturuyor.
    {  

        if(other.tag == "SpawnTrigger")     //player - isTrigger Spawn yeni tile
        { 
        spawnManager.SpawnTriggerGiris();  // Collidera giriþte tetiklenecek func. 
        }

        if(other.tag == "Diamond")       //player - isTrigger diamond 
        {
            gameManager.ToplananDiamond();      //playerdiamond++
            Destroy(other.gameObject);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Engel")//Engele temas ederse
        {
            Death();//olmeyi cagýr
        }
    }
    private void Death()
    {
        isAlive = false;
        gameManager.SaveScore(GameManager.mesafe,GameManager.playerDiamonds);
        StartCoroutine(dieDelay());
        animator.SetTrigger("crash");//olme animasyonu tetikle
        deathPanel.SetActive(true);
        GameManager.mesafe = 0;
        GameManager.playerDiamonds = 0;


    }
    IEnumerator dieDelay()
    {
        yield return new WaitForSeconds(2f);
        playerObject.SetActive(false);
        //Animasyon bitince karekteri sil
    }

     void hizArtis()
    {
        if (ileriHiz <= 15)               // Bölüm zorlugu üzerine geliþtirmelerle bu sýnýr da deðiþtirilebilir fakat oynanýþ açýsýndan pek saðlýklý olmayabilir.
        {

            ileriHiz += 0.1f;

        }
     
    }
   

}
