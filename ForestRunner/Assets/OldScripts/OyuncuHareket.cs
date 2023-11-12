using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuHareket : MonoBehaviour
{
    public float hiz = 5;  // inspector erisimi "public" -> yatayCarpan,hiz
    public Rigidbody rb;
    
   
 

    float yatayInput;
    public float yatayCarpan = 2;  

    private void FixedUpdate()
    {
        Vector3 ileriHareket = transform.forward * hiz * Time.fixedDeltaTime;
        Vector3 yatayHareket = transform.right * yatayInput * hiz * Time.fixedDeltaTime * yatayCarpan;
        rb.MovePosition(rb.position + ileriHareket + yatayHareket);
    }

    // Update is called once per frame
    void Update()
    {
        yatayInput = Input.GetAxis("Horizontal");
        
    }
}
