using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{


    public Transform oyuncu;
    Vector3 offset;

    void Start()
    {

        offset = transform.position - oyuncu.position;      // offset : kamera - oyuncu pozisyonu alýnýr
        
    }

    
    void Update()
    {
        //transform.position = oyuncu.position + offset;    // her framede oyuncu ile kamera arasýndaki mesafe korunacak
        
        Vector3 hedefPos = oyuncu.position + offset;
        hedefPos.x = 0;                                     //kamera oyuncunun x ekseni hareketlerini takip etmeyecek
        transform.position = hedefPos;
    }
}
