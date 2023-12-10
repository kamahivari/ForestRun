using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CevreSpawner : MonoBehaviour
{

                                      
    private float pcevreSize = 22f;      
    private float xPosSol= -14.98f;  //cevre platformlarýnýn ,karakter hareket platformu diþinda oluþmasi gereken pozisyonlarin degerleri
    private float xPosSag= 14.98f;
    //private float sonZPos = -3.59f;


    public List<GameObject> pcevreSol;
    public List<GameObject> pcevreSag;


    // Start is called before the first frame update
    void Start()
    {
      
        if(pcevreSol!=null && pcevreSag!=null&& pcevreSag.Count>0 && pcevreSol.Count>0)
        {

            pcevreSol = pcevreSol.OrderBy(z => z.transform.position).ToList();
            pcevreSag = pcevreSag.OrderBy(z => z.transform.position).ToList();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void SpawnPcevre()   //fonksiyona tasindi
    {

        GameObject movecevreSol = pcevreSol[0];
        GameObject movecevreSag = pcevreSag[0];
        pcevreSol.Remove(movecevreSol);
        pcevreSag.Remove(movecevreSag);
        float yeniZ = pcevreSol[pcevreSol.Count - 1].transform.position.z + pcevreSize;
        movecevreSol.transform.position = new Vector3(xPosSol, -1.82f, yeniZ);
        movecevreSag.transform.position = new Vector3(xPosSag, -1.82f, yeniZ);
        pcevreSol.Add(movecevreSol);
        pcevreSag.Add(movecevreSag);
    }
}
