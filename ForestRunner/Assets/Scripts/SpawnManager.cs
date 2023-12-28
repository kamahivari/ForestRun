using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    ZeminSpawner zeminSpawner;
   

    // Start is called before the first frame update
    void Start()
    {
        zeminSpawner = GetComponent<ZeminSpawner>();  //Spawn yönetimi sýnýfýndan nesneler çekilir.
       
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }


    public void SpawnTriggerGiris()
    {
        zeminSpawner.MoveZemin();
       

    }

    
}
