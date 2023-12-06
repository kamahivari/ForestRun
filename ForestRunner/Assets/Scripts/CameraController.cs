using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform hedef;
    Vector3 offset;



    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - hedef.position;
    }

    // Update is called once per frame
    void LateUpdate()         //PlayerMove scriptindeki Update() func. sonra smooth ge�i�
    {
        if (hedef!=null)
        {
            // transform.position = hedef.position + offset; ---> x axiste de�i�memesi gerekiyor
            Vector3 hedefPos = hedef.position + offset;
            hedefPos.x = 0;         //Kamera x axiste sabit
            transform.position = hedefPos;
        }

    }
}
