using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;

    public GameObject work;

    public GameObject house;


    // Start is called before the first frame update
    void Start()
    {
        GameObject businessman = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        businessman.GetComponent<PlayerController>().work_name = work.name;
        businessman.GetComponent<PlayerController>().house_name = house.name;
    }
}
