using UnityEngine;
    
    public class SampleStates
    {
        public StateMachineSample machine;
        public float elapsedTime { get; private set; }

        public SampleStates(StateMachineSample m) 
        {
            machine = m;
        }

        public virtual void OnEnter() 
        {
            Debug.Log("Entered state");
        }

        public virtual void OnUpdate() 
        {
            elapsedTime += Time.deltaTime;
        }

        public virtual void OnExit() 
        {
            Debug.Log("Exited state");
        }

    }
