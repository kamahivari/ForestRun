using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    ZeminSpawner zeminSpawner;
    CevreSpawner cevreSpawner; 


    // Start is called before the first frame update
    void Start()
    {
        zeminSpawner = GetComponent<ZeminSpawner>();  //Spawn y�netimi s�n�f�ndan nesneler �ekilir.
        cevreSpawner = GetComponent<CevreSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SpawnTriggerGiris()
    {
        zeminSpawner.MoveZemin();
        cevreSpawner.SpawnPcevre();
    }
}
