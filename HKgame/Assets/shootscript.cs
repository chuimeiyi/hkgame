using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class shootscript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D body;
    public float force;
    public string items;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        body.velocity = new Vector2 (direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update() {

    }
    



}
