using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    Rigidbody2D rigi;
    public float speed = -10;
    private void Awake()
    {
        rigi = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigi.velocity = transform.right*speed*Time.deltaTime;
    }
}
