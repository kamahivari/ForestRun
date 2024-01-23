using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracking : MonoBehaviour
{
    // Start is called before the first frame update
    public UDPReceive udpReceive;
    public GameObject[] handPoints;
    public Rigidbody rb;
    float x, y, z;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        string data = udpReceive.data;

        data = data.Remove(0, 1);
        data = data.Remove(data.Length - 1, 1);
        print(data);
        string[] points = data.Split(',');
        print(points[0]);

        //0        1*3      2*3
        //x1,y1,z1,x2,y2,z2,x3,y3,z3

        

             x = 7 - float.Parse(points[0]) / 100;
             y = float.Parse(points[1]) / 100;
             z = float.Parse(points[2]) / 100;

           
            Debug.Log(x);


        //float horizontalInput = x; // Sa�a ve sola hareket i�in giri� al
        //float verticalInput = y; ; // Yukar� ve a�a�� hareket i�in giri� al
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

        if (x < 3)
        {
            transform.localPosition = (transform.position + new Vector3(-0.005f, 0, 0));
        }
        else
        {
            transform.localPosition = (transform.position + new Vector3(0.005f, 0, 0));
        }













    }
    private void FixedUpdate()
    {
        

    }
}