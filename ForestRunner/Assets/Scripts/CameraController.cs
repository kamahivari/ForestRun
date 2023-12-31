using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform hedef;
    Vector3 offset;
   
    [SerializeField]
    PlayerMove playerScript;


    bool isAlive1 = PlayerMove.isAlive;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - hedef.position;
    }

    // Update is called once per frame
    void LateUpdate()         //PlayerMove scriptindeki Update() func. sonra smooth geçiþ
    {
        if (isAlive1)
        {

        
        if (hedef!=null)
        {
            // transform.position = hedef.position + offset; ---> x axiste deðiþmemesi gerekiyor
            Vector3 hedefPos = hedef.position + offset;
            hedefPos.x = 0;         //Kamera x axiste sabit
            transform.position = hedefPos;
        }

    }

    }
}
