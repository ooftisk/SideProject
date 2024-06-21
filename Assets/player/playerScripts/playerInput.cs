
using UnityEngine;
using UnityEngine.InputSystem;

public class playerInput : MonoBehaviour
{
    private SideProject input = null;
    private static Vector2 lStick = Vector2.zero;
    private static Vector2 rStick = Vector2.zero;

    private void Awake()
    {
        input = new SideProject();
    }

    public static Vector2 rightStick
    {
        get { return rStick; }
    }

    public static Vector2 leftStick
    {
        get { return lStick; }
    }


    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCancelled;
        input.Player.Look.performed += rightStickInputPerformed;
        input.Player.Look.canceled += rightStickInputCancelled;

    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCancelled;
        input.Player.Look.performed -= rightStickInputPerformed;
        input.Player.Look.canceled -= rightStickInputCancelled;
    }


    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        lStick = value.ReadValue<Vector2>();
        
    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        lStick = Vector2.zero;
    }

    private void rightStickInputPerformed(InputAction.CallbackContext value)
    {
        rStick = value.ReadValue<Vector2>();
    }

    private void rightStickInputCancelled(InputAction.CallbackContext value)
    {
        rStick = Vector2.zero;
    }

}
