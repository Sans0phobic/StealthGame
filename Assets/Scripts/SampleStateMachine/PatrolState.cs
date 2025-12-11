using UnityEngine;
using UnityEngine.AI;

public class PatrolState : SampleStates
{
    public PatrolState(StateMachineSample m) : base(m)
    {
        machine = m;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("Entered Patrol");
        machine.enemy.agent.destination = machine.enemy.PatrolPoints[machine.enemy.destinationPoint].transform.position;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (!machine.enemy.agent.pathPending && machine.enemy.agent.remainingDistance < 0.5f)
            machine.ChangeState(new IdleState(machine));
    }

    public override void OnExit()
    {
        base.OnExit();
    }

}
