using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject spawner;
    public GameObject chicken;
    public GameObject condor;
    public GameObject dragon;

    private float timer = 0f;
    private bool chickenSpawned = false;
    private bool condorSpawned = false;
    private bool dragonSpawned = false;

    private Vector3 spawn1;
    private Vector3 spawn2;
    private Vector3 spawn3;

    // Start is called before the first frame update
    void Start()
    {
        spawn1 = new Vector3(spawner.transform.position.x + 10, spawner.transform.position.y, spawner.transform.position.z + 10);
        spawn2 = new Vector3(spawner.transform.position.x + 10, spawner.transform.position.y, spawner.transform.position.z);
        spawn3 = new Vector3(spawner.transform.position.x + 10, spawner.transform.position.y, spawner.transform.position.z + 20);
    }

    // Update is called once per frame



    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2f && timer < 2.3f)
        {
            if (!chickenSpawned)
            {
                Instantiate(chicken, spawn1, Quaternion.identity);
                chickenSpawned = true;
            }          
        }
        else
            chickenSpawned = false;


        if (timer > 7f && timer < 7.3f)
        {
            if (!condorSpawned)
            {
                Instantiate(condor, spawn2 + new Vector3(0, 5f, 0), Quaternion.identity);
                condorSpawned = true;
            }
        }
        else
            condorSpawned = false;

        if (timer > 11f && timer < 11.3f)
        {
            if (!dragonSpawned)
            {
                Instantiate(dragon, spawn3 + new Vector3(0, 10f, 0), Quaternion.identity);
                dragonSpawned = true;
            }
        }
        else
            dragonSpawned = false;


        if (timer > 14f)
        {
            Vector3 hold = spawn3;
            spawn3 = spawn1;
            spawn1 = spawn2;
            spawn2 = hold;

            timer = 0f;
        }
            
    }
}
