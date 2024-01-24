using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
   


    }
    IEnumerator JumpCorrutine()
    {
        // Kullanýcý zýpladýðý aný iþaretleyerek birden fazla zýplamayý engelleyelim
        canJump = false;

        // Zýplama iþlemini gerçekleþtir
        PlayerMove.motionJump = true;

        // 2 saniye bekle
        yield return new WaitForSeconds(0.7f);

        // 2 saniye sonra tekrar zýplamaya izin ver
        canJump = true;
    }
    private void FixedUpdate()
    {

        try
        {
            string data = udpReceive.data;

            ;
            data = data.Replace('(', ' ');
            data = data.Replace(')', ' ');
            string[] points = data.Split(',');



            //TryParse ile degerleri kontrol ediyoruz
            if (float.TryParse(points[0], NumberStyles.Float, CultureInfo.InvariantCulture, out x))
            {
                // Baþarýlý dönüþüm, x deðiþkenini kullanabilirsiniz.
                x = x / 10;
                if (float.TryParse(points[1], NumberStyles.Float, CultureInfo.InvariantCulture, out y))
                {
                    y = y / 10;

                }

            }
            if (x > 35) //sað sol
            {
                if (this.gameObject.transform.position.x > LevelSinir.solTrf)
                {
                    transform.localPosition = (transform.position + new Vector3(-0.02f, 0, 0));
                }
            }
            else if (x < 35)
            {
                if (this.gameObject.transform.position.x > LevelSinir.sagTrf)
                {
                    transform.localPosition = (transform.position + new Vector3(0.02f, 0, 0));
                }
            }

            if (canJump && y < 8 && y > 0)
            {
                StartCoroutine(JumpCorrutine());

            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }




    }
}