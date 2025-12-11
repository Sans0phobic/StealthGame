using NUnit.Framework;
using System.Collections.Generic;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlaceholderEnemy : MonoBehaviour
{
    [Header("References")]
    StateMachineSample stateMachine;
    public List<GameObject> PatrolPoints = new List<GameObject>();
    public NavMeshAgent agent { get; private set; }
    public Transform lastPlayerPoint;
    public GameObject player;
    public LayerMask layer;

    public float cutOffAngle = 45.0f;
    public bool lineOfSight = false;
    public bool playerChased = false;
    public bool heardPlayer = false;
    public bool wallCheck = false;
    public int destinationPoint = 0;

    private Vector3 direction;

    void Start()
    {
        stateMachine = new StateMachineSample(this);
        agent = GetComponent<NavMeshAgent>();
        layer = LayerMask.GetMask("Environment");
        stateMachine.ChangeState(new PatrolState(stateMachine));
    }

    void Update()
    {
        stateMachine.Update();
        if (lineOfSight)
        {
            stateMachine.ChangeState(new PursueState(stateMachine));
        }
    }

    void FixedUpdate()
    {
        Vector3 dirPlayer = (player.transform.position - transform.position).normalized;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, dirPlayer, out hit, 15.0f, layer))
        {
            Debug.DrawRay(transform.position, dirPlayer * hit.distance, Color.orangeRed);
            lineOfSight = false;
            wallCheck = true;
        }
        else if(TargetInFront() && !Physics.Raycast(transform.position, dirPlayer, out hit, 15.0f, layer))
        {
            lineOfSight = true;
        }

        if (!Physics.Raycast(transform.position, dirPlayer, out hit, 15.0f, layer))
        {
            wallCheck = false;
        }
    }

    float GetDotProduct() 
    {
        Debug.DrawRay(transform.position, transform.forward, Color.yellow);

        direction = player.transform.position - transform.position;
        direction.Normalize();

        Debug.DrawRay(transform.position, direction, Color.green);

        return Vector3.Dot(transform.forward, direction);
    }

    bool TargetInFront() 
    {
        float desAngle = Mathf.Acos(GetDotProduct() / (transform.forward).magnitude * direction.magnitude);
        desAngle *= Mathf.Rad2Deg;

        if (Mathf.Abs(desAngle) < cutOffAngle) 
        {
            return true;
        }

        return false;
    }

    public void FuncHeard() 
    {
        if (!wallCheck)
        {
            heardPlayer = true;
            stateMachine.ChangeState(new PursueState(stateMachine));
        }
    }

    public void FuncCaught() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
