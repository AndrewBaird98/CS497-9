using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State<AI>
{
    private static AttackState instance;

    private AttackState()
    {
        if (instance != null)
            return;

        instance = this;
    }

    public static AttackState Instance
    {
        get
        {
            if (instance == null)
                new AttackState();

            return instance;
        }
    }

    public override void EnterState(AI owner)
    {
        Debug.Log("Entered Attack State");
    }

    public override void ExitState(AI owner)
    {
        Debug.Log("Exited Attack State");
    }

    public override void UpdateState(AI owner)
    {
        var dist = Vector3.Distance(owner.aiCharacter.transform.position, owner.player.transform.position);

        if (dist < 2f)
        {
            //game over
        }
        if (dist > 5f)
        {
            owner.stateMachine.ChangeState(AlertState.Instance);
        }

        owner.aiCharacter.transform.LookAt(owner.player.transform);

        owner.aiCharacter.transform.position = Vector3.MoveTowards(owner.aiCharacter.transform.position, owner.player.transform.position, 2f * Time.deltaTime);
    }
}
