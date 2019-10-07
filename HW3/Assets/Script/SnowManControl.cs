using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowManControl : MonoBehaviour
{
    public enum State
    {
        idleAround,
        upset,
        angry     
    }
    public State snowmanState;
    public GameObject player;

    //snow man idle state variables
    private float upsetDistance = 4.0f;
    private float speed=1.0f;
    private bool firstEnterIdle = true;
    private Vector3 startPos;
    private bool goingLeft=true;
    //snow man upset state variables
    private bool hit = false;
    //snow man angry state variables
    private float escapeDistance = 5.0f;
    private float chaseSpeed = 0.5f;
    private float chaseDistance = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        snowmanState = State.idleAround;
    }

    // Update is called once per frame
    void Update()
    {
        switch (snowmanState) {
            case State.idleAround:
                //normal behavior with this state, move left/right
                if (firstEnterIdle)
                {
                    startPos = transform.transform.position;
                    firstEnterIdle = false;
                }
                if (goingLeft)
                {
                    transform.Translate(-Vector3.left * speed * Time.deltaTime);
                    if (Vector3.Distance(transform.position, startPos) > 2.0f)
                        goingLeft = false;
                }
                else
                {
                    transform.Translate(-Vector3.right * speed * Time.deltaTime);
                    if (Vector3.Distance(transform.position, startPos) > 2.0f)
                        goingLeft = true;
                }

                //change state condition, if you are nearby
                float distance = Vector3.Distance(transform.position, player.transform.position);
                if (distance < upsetDistance)
                {
                    snowmanState = State.upset;
                    firstEnterIdle = true;
                }
                break;
            case State.upset:
                //normal behavior with this state, turn towards you and stare at you
                transform.LookAt(player.transform);


                //Change state conditions
                //if you are gone
                if (Vector3.Distance(transform.position, player.transform.position) > escapeDistance)
                    snowmanState = State.idleAround;
                //if you hit him once
                if (hit)
                {
                    snowmanState = State.angry;
                }
                break;
            case State.angry:
                //normal behavior with this state, turn towards you and chase you
                
                if (Vector3.Distance(transform.position, player.transform.position) > chaseDistance)
                {
                    transform.LookAt(player.transform);
                    //transform.position += transform.forward *chaseSpeed * Time.deltaTime; This call will get snowman underground if the camera is lower than the snowman eyelevel
                    //move towards target: player position with y set to snowman eye level & chase
                    transform.position=Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y, player.transform.position.x), chaseSpeed * Time.deltaTime);
                    
                }

                //change state condition: if you are gone
                if(Vector3.Distance(transform.position,player.transform.position)> escapeDistance)
                    snowmanState = State.idleAround;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("Cube"))
            hit = true;
    }
}
