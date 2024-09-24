using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(IControllable))]
public class CharacterInputController : MonoBehaviour
{
    private IControllable _controllable;
    private GameInputMap _gameInput;

    private void Awake()
    {
        _gameInput = new GameInputMap();
        _gameInput.Enable();
        _controllable = GetComponent<IControllable>();
        _gameInput.PlayerInput.Jump.performed += OnJumpPerformed;
    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        _controllable.Jump();
    }

    private void OnDestroy()
    {
        _gameInput.PlayerInput.Jump.performed -= OnJumpPerformed;
    }

    private void Update()
    {
        ReadMovement();
    }

    private void ReadMovement()
    {
        var inputDirection = _gameInput.PlayerInput.Movement.ReadValue<Vector2>();
        var direction = new Vector3(inputDirection.x, 0f, 0f);

        _controllable.Move(direction);
    }
}
