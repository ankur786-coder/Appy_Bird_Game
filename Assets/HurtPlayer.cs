//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerController.instance.health -= 1f;
            PlayerController.instance.PlayhitSound();
            Destroy(this.gameObject);
        }
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
