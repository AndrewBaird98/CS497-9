using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public GameObject self;
    private Transform target;
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("MonsterTarget").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);

        float step = speed * Time.deltaTime; 
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        if (Vector3.Distance(transform.position, target.position) < 1.7f)
        {
            Destroy(self);
        }
    }
}
