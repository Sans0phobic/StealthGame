using UnityEngine;

public class goal : MonoBehaviour
{
    [SerializeField] Canvas canva;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Player")) 
        {
            canva.enabled = true;
        }
    }
}
