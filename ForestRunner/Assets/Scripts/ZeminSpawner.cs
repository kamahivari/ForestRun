using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ZeminSpawner : MonoBehaviour
{

    public List<GameObject> zeminler;  //Zemin prefablerini içerisinde tutacak Gameobject türünde List -> Ýnspectordan editlenebilir
    private float offset = 30f;
    
    // Start is called before the first frame update
    void Start()
    {
        
        if(zeminler !=null && zeminler.Count>0)
        {
            zeminler = zeminler.OrderBy(z => z.transform.position.z).ToList();  //listeye atýlan zemin objelerini sýralar

        }



    }

    public void MoveZemin()
    {

        GameObject moveZemin = zeminler[0]; //listenin ilk elemanýný al
        zeminler.Remove(moveZemin);
        float yeniZ = zeminler[zeminler.Count - 1].transform.position.z + offset;                           //son elemanýnýn konumuna ve uzaklýðýmýza göre yeni Z deðerini hesaplamak
        moveZemin.transform.position = new Vector3(0, 0, yeniZ);
        zeminler.Add(moveZemin); //listenin baþýna tekrar eklemek zorunda kalmadan ekleyecektir. -- Execute edildi ; z1-z2-z3 sýrasýný tekrar elde ediyoruz.
    }
}
