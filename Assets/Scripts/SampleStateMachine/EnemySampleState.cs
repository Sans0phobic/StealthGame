using UnityEngine;

    public class EnemySampleState : SampleStates
    {
        public EnemySampleState(StateMachineSample m) : base(m)
        {
            machine = m;
        }

        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            //Use elapsed time to check time, it will reset every time you switch states
        }

        public override void OnExit()
        {
            base.OnExit();
        }

    }

