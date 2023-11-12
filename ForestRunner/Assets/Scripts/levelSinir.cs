using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSinir : MonoBehaviour
{
    public static float solTrf = -3.5f;
    public static float sagTrf = 3.5f;
    public float dahilSol;
    public float dahilSag;


    void Update()
    {
        dahilSol = solTrf;
        dahilSag = sagTrf; 
        
    }
}
