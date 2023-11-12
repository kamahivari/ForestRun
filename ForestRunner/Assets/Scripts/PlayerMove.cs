using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{


    public float ileriHiz= 3;
    public float solsagHiz = 4;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * ileriHiz,Space.World);
        
        if ((Input.GetKey(KeyCode.A)) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > LevelSinir.solTrf)
            {
                transform.Translate(Vector3.left * Time.deltaTime * solsagHiz);
            }

        }

        if ((Input.GetKey(KeyCode.D)) || Input.GetKey(KeyCode.RightArrow))
        {

            if (this.gameObject.transform.position.x < LevelSinir.sagTrf)
            {
                transform.Translate(Vector3.left * Time.deltaTime * solsagHiz * -1);
            }
        }


    }
}
