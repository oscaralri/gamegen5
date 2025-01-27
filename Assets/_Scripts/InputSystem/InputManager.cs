using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private InputSystem_Actions _inputActions;

    private void Awake()
    {
        _inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        // UI
        _inputActions.UI.Enable();
        _inputActions.UI.Click.performed += OnClick;

    }

    private void OnClick(InputAction.CallbackContext context)
    {
        //Debug.Log("Click");
    }
}
