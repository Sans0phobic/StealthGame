using System.Globalization;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private PlayerInputHandler playerInputHandler;
    [SerializeField] private PlayerStats playerStats;

    [Header("Movement Speed")]
    private float playerSpeed;

    private Vector3 currentMovement;
    public bool crouched { get; private set; }
    public UnityEvent CaughtEvent;
    public UnityEvent HeardEvent;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        crouched = false;
        playerSpeed = playerStats.playerSpeed;
    }

    void Update()
    {
        HandleMovement();

        if (playerInputHandler.CrouchTriggered)
        {
            playerSpeed = 2.5f;
            crouched = true;
        }
        else 
        {
            playerSpeed = playerStats.playerSpeed;
            crouched = false;
        }
    }

    private Vector3 CalculateWorldDirection()
    {
        Vector3 inputDirection = new Vector3(playerInputHandler.MovementInput.x, 0.0f, playerInputHandler.MovementInput.y);
        Vector3 worldDirection = transform.TransformDirection(inputDirection);
        return worldDirection;
    }

    private void HandleMovement()
    {
        Vector3 worldDirection = CalculateWorldDirection();
        currentMovement.x = worldDirection.x * playerSpeed;
        currentMovement.z = worldDirection.z * playerSpeed;
        characterController.Move((currentMovement) * Time.deltaTime);
    }

    private void OnControllerColliderHit(UnityEngine.ControllerColliderHit hit)
    {
        if (hit.gameObject.name.Equals("EnemyBody")) 
        {
            CaughtEvent?.Invoke();
        }
    }
}
