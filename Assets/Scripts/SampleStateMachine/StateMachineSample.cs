using UnityEngine;

    public class StateMachineSample
    {
        SampleStates currentState;
        public PlaceholderEnemy enemy { get; private set; }

        public StateMachineSample(PlaceholderEnemy enemy)
        {
            this.enemy = enemy;
        }

    public void Update() 
        {
            currentState?.OnUpdate();
        }

        public void ChangeState(SampleStates newState) 
        {
            currentState?.OnExit();

            currentState = newState;

            currentState.OnEnter();
        }
    }