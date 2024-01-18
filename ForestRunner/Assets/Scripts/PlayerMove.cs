using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{

    public static bool isAlive=true; //Karekter hayattam�
    public float ileriHiz = 3;
    public float solsagHiz = 4;

    public bool zipliyorMu = false;  //default  -->> Z�plama 2 a�amal� ; y�kselme ve d�sme
    public bool dusuyorMu = false;

 
    public GameObject playerObject;

    public GameManager gameManager;
   
    //------------------------------------------------------------------------------------------------->�nscpector pencerisinden m�dahale edilebilecek sat�rlar
                   
    [SerializeField] float ziplamaKuvveti = 3f;
    [SerializeField] float ziplamaAraligi = 0.45f;
    [SerializeField] Animator animator;
    [SerializeField] GameObject deathPanel;
    



    [SerializeField] Rigidbody rb;

    public SpawnManager spawnManager;


 
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("hizArtis", 30f,30f); // Belirli bir zaman aral���nda uyand�r�lacak fonksiyon ; 30sn sonra ilk uyand�rma - 30sn araliklarla ;; 
                                                // Level Scaling ve Zorluk a�amas� i�in modifiye edilebilir - geli�tirilebilir.
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isAlive)
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

                animator.SetTrigger("jump");//Jump Animasyonunu Tetikle

                StartCoroutine(ZiplamaSirasi()); // Coroutine �ali�tirarak belli bir s�reyle tekrar tekrar �al��abilecek bir yapi saglanir

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
        float ilkYukseklik = transform.position.y; //ilk yuksekligi almad���m�zda karaktere ardarda z�pla komutu verince ger�ek y ekseni koordinat� bozuluyor
        yield return new WaitForSeconds(ziplamaAraligi);
        dusuyorMu = true;
        yield return new WaitForSeconds(ziplamaAraligi);         //belli bir s�re beklemesini sa�layabiliriz z�plamas� i�in
        zipliyorMu = false;
        dusuyorMu = false;
        
        transform.position = new Vector3(transform.position.x, ilkYukseklik, transform.position.z);
    }



 
    private void OnTriggerEnter(Collider other)                    //SpawnManager-ZeminSpawner;3.ad�m -> Player Collider'a girince tetiklenerek s�radaki zemini olu�turuyor.
    {  

        if(other.tag == "SpawnTrigger")     //player - isTrigger Spawn yeni tile
        { 
        spawnManager.SpawnTriggerGiris();  // Collidera giri�te tetiklenecek func. 
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
            Death();//olmeyi cag�r
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
        if (ileriHiz <= 15)               // B�l�m zorlugu �zerine geli�tirmelerle bu s�n�r da de�i�tirilebilir fakat oynan�� a��s�ndan pek sa�l�kl� olmayabilir.
        {

            ileriHiz += 0.1f;

        }
     
    }
   

}
