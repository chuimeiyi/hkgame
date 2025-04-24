using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public GameObject[] objects;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnItem", 0.5f, 1);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnItem() {

        
        Instantiate(objects[Random.Range(0,1)], spawnPoint[Random.Range(0, 14)].position,Quaternion.identity);



    }


}
