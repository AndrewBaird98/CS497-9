using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveState : State<AI>
{
    private static PassiveState instance;
    
    private PassiveState()
    {
        if (instance != null)
            return;

        instance = this;
    }

    public static PassiveState Instance
    {
        get
        {
            if (instance == null)
                new PassiveState();

            return instance;
        }
    }

    public override void EnterState(AI owner)
    {
        Debug.Log("Entered Passive State");
    }

    public override void ExitState(AI owner)
    {
        Debug.Log("Exited Passive State");
    }

    public override void UpdateState(AI owner)
    {
        var dist = Vector3.Distance(owner.aiCharacter.transform.position, owner.player.transform.position);

        if (dist < 10f)
        {
            owner.stateMachine.ChangeState(AlertState.Instance);
        }
    }
}
