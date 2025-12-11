using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [Header("Input Action Asset")]
    [SerializeField] private InputActionAsset playerControls;

    [Header("Action Map Name Reference")]
    [SerializeField] private string actionMapName = "playerInput"; //Name the action map, not the input action

    [Header("Action Name References")]
    [SerializeField] private string movement = "PlayerMovement";
    [SerializeField] private string crouched = "PlayerCrouch";

    private InputAction movementAction;
    private InputAction crouchedAction;

    public Vector2 MovementInput { get; private set; }
    public bool CrouchTriggered { get; private set; }

    private void Awake()
    {
        InputActionMap mapReference = playerControls.FindActionMap(actionMapName);

        movementAction = mapReference.FindAction(movement);
        crouchedAction = mapReference.FindAction(crouched);

        SubscribeActionValuesToInputEvents();
    }

    private void SubscribeActionValuesToInputEvents()
    {
        movementAction.performed += inputInfo => MovementInput = inputInfo.ReadValue<Vector2>();
        movementAction.canceled += inputInfo => MovementInput = Vector2.zero;

        crouchedAction.performed += inputInfo => CrouchTriggered = true;
        crouchedAction.canceled += inputInfo => CrouchTriggered = false;
    }

    private void OnEnable()
    {
        playerControls.FindActionMap(actionMapName).Enable();
    }

    private void OnDisable()
    {
        playerControls.FindActionMap(actionMapName).Disable();
    }
}