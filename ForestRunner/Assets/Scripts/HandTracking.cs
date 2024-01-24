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
        //string data = udpReceive.data;

        //data = data.Remove(0, 1);
        //data = data.Remove(data.Length - 1, 1);
        //print(data);
        //string[] points = data.Split(',');
        //print(points[0]);

        ////0        1*3      2*3
        ////x1,y1,z1,x2,y2,z2,x3,y3,z3



        //     x = 7 - float.Parse(points[0]) / 100;
        //     y = float.Parse(points[1]) / 100;
        //     z = float.Parse(points[2]) / 100;


        //    Debug.Log(x);


        //float horizontalInput = x; // Saða ve sola hareket için giriþ al
        //float verticalInput = y; ; // Yukarý ve aþaðý hareket için giriþ al
        //if (horizontalInput>3 && horizontalInput < 10)
        //{
        //    horizontalInput = 1;
        //    Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * 1f * Time.deltaTime;
        //    rb.AddForce(transform.position + movement);
        //}
        //else if(horizontalInput<3&& horizontalInput<10)
        //{
        //    horizontalInput = -1;
        //    Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * 1f * Time.deltaTime;
        //    rb.AddForce(transform.position + movement);
        //}

        //if (x < 3)
        //{
        //    transform.localPosition = (transform.position + new Vector3(-0.005f, 0, 0));
        //}
        //else
        //{
        //    transform.localPosition = (transform.position + new Vector3(0.005f, 0, 0));
        //}










        string data = udpReceive.data;
        
;
        data = data.Replace('(', ' ');
        data = data.Replace(')', ' ');
        string[] points = data.Split(',');
        

        x = float.Parse(points[0])/10;
        y = float.Parse(points[1])/10;

       
            if (x > 35) //sað sol
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
        

    }
}