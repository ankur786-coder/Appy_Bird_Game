using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSpawner : MonoBehaviour
{
    public GameObject GameObjectToSpawn;
    private GameObject Clone;
    public float timeToSpawn = 4f;
    public float FirstSpawn = 10f;

    void Update()
    {
        FirstSpawn -= Time.deltaTime;
        if(FirstSpawn <= 0f)
        {
            Clone = Instantiate(GameObjectToSpawn, gameObject.transform.localPosition, Quaternion.identity) as GameObject;
            FirstSpawn = timeToSpawn;
        }
    }
}
