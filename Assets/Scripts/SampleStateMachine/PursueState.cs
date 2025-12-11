using UnityEngine;

public class PursueState : SampleStates
{
    public PursueState(StateMachineSample m) : base(m)
    {
        machine = m;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("Entered Pursue");
        machine.enemy.playerChased = true;
        machine.enemy.lastPlayerPoint.position = machine.enemy.player.transform.position;
        machine.enemy.heardPlayer = false;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (machine.enemy.lineOfSight)
        {
            machine.enemy.lastPlayerPoint.position = machine.enemy.player.transform.position;
        }
        machine.enemy.agent.destination = machine.enemy.lastPlayerPoint.position;

        if (!machine.enemy.agent.pathPending && machine.enemy.agent.remainingDistance < 0.3f)
            machine.ChangeState(new InvestigateState(machine));
    }

    public override void OnExit()
    {
        base.OnExit();
    }

}
