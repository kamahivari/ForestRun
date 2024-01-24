using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracking : MonoBehaviour
{
    // Start is called before the first frame update
    public UDPReceive udpReceive;
    private bool canJump = true;
    public Rigidbody rb;
    
    float x, y, z;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        try { 
       string data = udpReceive.data;
        
;
        data = data.Replace('(', ' ');
        data = data.Replace(')', ' ');
        string[] points = data.Split(',');
        

        x = float.Parse(points[0])/10;
        y = float.Parse(points[1])/10;

       
            if (x > 35) //sa� sol
            {
            if (this.gameObject.transform.position.x > LevelSinir.solTrf) { 
                transform.localPosition = (transform.position + new Vector3(-0.005f, 0, 0));
            }
        }
            else if (x < 35)
            {
            if (this.gameObject.transform.position.x > LevelSinir.solTrf)
            {
                transform.localPosition = (transform.position + new Vector3(0.005f, 0, 0));
            }
        }

        if (canJump &&  y < 8 && y > 0 )
        {
            StartCoroutine(JumpCorrutine());
            
        }
        }
        catch(Exception e) 
        {
            Debug.LogError(e);
        }






    }
    IEnumerator JumpCorrutine()
    {
        // Kullan�c� z�plad��� an� i�aretleyerek birden fazla z�plamay� engelleyelim
        canJump = false;

        // Z�plama i�lemini ger�ekle�tir
        PlayerMove.motionJump = true;

        // 2 saniye bekle
        yield return new WaitForSeconds(0.7f);

        // 2 saniye sonra tekrar z�plamaya izin ver
        canJump = true;
    }
    private void FixedUpdate()
    {

       
    }
}