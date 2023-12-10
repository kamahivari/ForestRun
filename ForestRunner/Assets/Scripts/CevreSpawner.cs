using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CevreSpawner : MonoBehaviour
{

    private int baslangcMiktar = 10;                                   
    private float pcevreSize = 22f;      
    private float xPosSol= -14.98f;  //cevre platformlarýnýn ,karakter hareket platformu diþinda oluþmasi gereken pozisyonlarin degerleri
    private float xPosSag= 14.98f;
    private float sonZPos = -3.59f;


    public List<GameObject> pcevre;


    // Start is called before the first frame update
    void Start()
    {
        
        for(int i = 0 ; i<baslangcMiktar;i++)
        {

            SpawnPcevre();

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void SpawnPcevre()   //fonksiyona tasindi
    {
        
        GameObject pcevreSol = pcevre[Random.Range(0, pcevre.Count)];
        GameObject pcevreSag = pcevre[Random.Range(0, pcevre.Count)];   // sag-sol cevre objeleri list elemaný arasinda random secilecek-->> Arayuzden mudahele edip degistirilebilecek bu cesitlilik

        float zPos = sonZPos + pcevreSize;    //yeni belirlenecek Z ekseni pozisyonu --> son spawn noktasi + spawn olacak obje boyutu kadar

       GameObject CevreSol= Instantiate(pcevreSol, new Vector3(xPosSol, -1.82f, zPos), pcevreSol.transform.rotation);  //Vector3 nesnesi ile yeni orneklendirme yapiliyor ve koordinatlari verildi.
       GameObject CevreSag= Instantiate(pcevreSag, new Vector3(xPosSag, -1.82f, zPos), new Quaternion(0, 180, 0, 0));  //sag platform 180 derece dondurulecek

        sonZPos += pcevreSize; //son Z posziyonu tutulacak her bir platform eklendiginde

        Destroy(CevreSag, 150f);     //optimize edilebilir bir yapý ; Cevresol-sag sonradan atanan deðiþkenler. Nondeterministik bir yapý var burda
        Destroy(CevreSol, 150f); 
    }
}
