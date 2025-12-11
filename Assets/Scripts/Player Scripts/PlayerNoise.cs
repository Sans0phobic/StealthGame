using UnityEngine;
using UnityEngine.Events;

public class PlayerNoise : MonoBehaviour
{
    [SerializeField] PlayerMovement pMove;

    private Vector3 previousPos;
    private bool hasMoved;

    public void Start()
    {
        pMove.transform.hasChanged = false;
        previousPos = transform.position;
    }

    public void Update()
    {
        hasMoved = false;
        if (previousPos != transform.position) 
        {
            hasMoved = true;
            previousPos = transform.position;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (!pMove.crouched && other.gameObject.name.Equals("EnemyHearingRange") && hasMoved)
        {
            pMove.HeardEvent?.Invoke();
        }
    }
}
