using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public GameObject player;
    public GameObject aiCharacter;

    public StateMachine<AI> stateMachine { get; set; }
   
    // Start is called before the first frame update
    void Start()
    {  
        stateMachine = new StateMachine<AI>(this);
        stateMachine.ChangeState(PassiveState.Instance);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }
}
