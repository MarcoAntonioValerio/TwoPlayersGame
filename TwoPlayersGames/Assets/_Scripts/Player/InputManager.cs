using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class InputManager : MonoBehaviour
{
    private Controls touchControls;

    private void Awake()
    {
        touchControls = new Controls();
    }

    private void OnEnable()
    {
        touchControls.Enable();
    }

    private void OnDisable()
    {
        touchControls.Disable();
    }

    private void Start()
    {
        touchControls.Player.TouchPress.started += ctx => TouchStarted(ctx);
        touchControls.Player.TouchPress.canceled += ctx => TouchCanceled(ctx);
    }

    private void TouchStarted(InputAction.CallbackContext context)
    {
        Debug.Log("Touch Started at " + touchControls.Player.TouchPosition.ReadValue<Vector2>());
    }

    private void TouchCanceled(InputAction.CallbackContext context)
    {

    }
}
