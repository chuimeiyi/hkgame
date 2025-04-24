using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public GameObject[] Objects;

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

        
        Instantiate(Objects[Random.Range(0, 1)], spawnPoint[Random.Range(0, 15)].position,Quaternion.identity);



    }


}
