using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ZeminSpawner : MonoBehaviour
{

    public List<GameObject> zeminler;  //Zemin prefablerini i�erisinde tutacak Gameobject t�r�nde List -> �nspectordan editlenebilir
    private float offset = 30f;
    
    // Start is called before the first frame update
    void Start()
    {
        
        if(zeminler !=null && zeminler.Count>0)
        {
            zeminler = zeminler.OrderBy(z => z.transform.position.z).ToList();  //listeye at�lan zemin objelerini s�ralar

        }



    }

    public void MoveZemin()
    {

        GameObject moveZemin = zeminler[0]; //listenin ilk eleman�n� al
        zeminler.Remove(moveZemin);
        float yeniZ = zeminler[zeminler.Count - 1].transform.position.z + offset;                           //son eleman�n�n konumuna ve uzakl���m�za g�re yeni Z de�erini hesaplamak
        moveZemin.transform.position = new Vector3(0, 0, yeniZ);
        zeminler.Add(moveZemin); //listenin ba��na tekrar eklemek zorunda kalmadan ekleyecektir. -- Execute edildi ; z1-z2-z3 s�ras�n� tekrar elde ediyoruz.
    }
}
