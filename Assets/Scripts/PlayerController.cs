using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour
{
    public GameObject player;

    public NavMeshAgent agent;

    public ThirdPersonCharacter character;

    public string work_name;
    public string house_name;
    private Vector3 work;
    private Vector3 house;

    private bool atWork;

    private float timer = 0.0f;
    private int seconds;

    void Start()
    {
        agent.updateRotation = false;

        // Define the Vector3 of the destinations
        Vector3 position = GameObject.Find(work_name).transform.position;
        work = new Vector3(position.x, 1, position.z + 2.5f);

        position = GameObject.Find(house_name).transform.position;
        house = new Vector3(position.x, 1, position.z - 2.5f);

        // Initial Destination
        agent.SetDestination(work);
        atWork = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
            atWork = true;
        }

        if (atWork)
        {
            timer += Time.deltaTime;
            seconds = (int)(timer % 60);
            if (seconds >= 5)     // Goes home after 5 seconds at work
            {
                agent.SetDestination(house);
            }
        }
    }
}
