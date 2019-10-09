using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertState : State<AI>
{
    private static AlertState instance;

    private AlertState()
    {
        if (instance != null)
            return;

        instance = this;
    }

    public static AlertState Instance
    {
        get
        {
            if (instance == null)
                new AlertState();

            return instance;
        }
    }

    public override void EnterState(AI owner)
    {
        Debug.Log("Entered Alert State");
    }

    public override void ExitState(AI owner)
    {
        Debug.Log("Exited Alert State");
    }

    public override void UpdateState(AI owner)
    {
        var dist = Vector3.Distance(owner.aiCharacter.transform.position, owner.player.transform.position);

        if (dist < 5f)
        {
            owner.stateMachine.ChangeState(AttackState.Instance);
        }
        else if (dist > 10f)
        {
            owner.stateMachine.ChangeState(PassiveState.Instance);
        }

        owner.aiCharacter.transform.LookAt(owner.player.transform);
    }
}
