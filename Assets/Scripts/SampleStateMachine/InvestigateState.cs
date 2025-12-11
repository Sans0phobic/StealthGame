using UnityEngine;

public class InvestigateState : SampleStates
{
    public InvestigateState(StateMachineSample m) : base(m)
    {
        machine = m;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("Entered Investigate");
        machine.enemy.playerChased = true;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (elapsedTime <= 0.75f)
            machine.enemy.transform.Rotate(Vector3.up * 150f * Time.deltaTime);
        else if (elapsedTime > 2f && elapsedTime <= 3.5f)
            machine.enemy.transform.Rotate(Vector3.down * 150f * Time.deltaTime);
        else if (elapsedTime >= 5f)
            machine.ChangeState(new IdleState(machine));
    }

    public override void OnExit()
    {
        base.OnExit();
    }

}
