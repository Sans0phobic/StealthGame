using UnityEngine;

public class IdleState : SampleStates
{
    public IdleState(StateMachineSample m) : base(m)
    {
        machine = m;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("Entered Idle");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (!machine.enemy.playerChased && elapsedTime >= 3.0f)
        {
            machine.enemy.destinationPoint++;
            if (machine.enemy.destinationPoint >= machine.enemy.PatrolPoints.Count)
            {
                machine.enemy.destinationPoint = 0;
            }  
            machine.ChangeState(new PatrolState(machine));
        }
        else if (machine.enemy.playerChased && elapsedTime >= 3.0f) 
        {
            Debug.Log("That player was chased alright");
            machine.enemy.playerChased = false;
            machine.ChangeState(new PatrolState(machine));
        }
        
    }

    public override void OnExit()
    {
        base.OnExit();
    }

}
