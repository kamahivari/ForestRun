using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondSpawner : MonoBehaviour
{
    public GameObject[] diamondPreb;
    public float zSpawn = 15;
    public float diamondAralik = 5;
    public int diamondSayi = 5;

    private List<GameObject> aktifDiamond = new List<GameObject>();
    public Transform playerTransform;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < diamondSayi; i++)
        {
            if (i == 0)
                SpawnEngel(0);
            else
                SpawnEngel(Random.Range(0,diamondPreb.Length));

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z > zSpawn - (diamondSayi * diamondAralik))   // -35>
        {
            SpawnEngel(Random.Range(0, diamondPreb.Length));
            DeleteEngel();
        }

    }


    public void SpawnEngel(int diamIndex)
    {
        float xPos = Random.Range(-3.4f, 3.5f);
        float yPos = 2.1f;


        GameObject aktif = Instantiate(diamondPreb[diamIndex], new Vector3(xPos,yPos,zSpawn), transform.rotation);
        aktifDiamond.Add(aktif);
        zSpawn += diamondAralik;


    }

    private void DeleteEngel()
    {
        Destroy(aktifDiamond[0], 5f); //gecikme
        aktifDiamond.RemoveAt(0);
    }


}
