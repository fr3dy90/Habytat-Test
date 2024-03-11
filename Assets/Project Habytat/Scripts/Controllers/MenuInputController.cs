using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuInputController : MonoBehaviour
{
    public static MenuInputController Instance;
    [SerializeField] private InputPlayerActions _inputPlayerActions;
    public Action onAcceopt;
    public Action onDecline;
    public Action onClose;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        _inputPlayerActions ??= new();
    }

    private void OnEnable()
    {
        _inputPlayerActions.Interactions.Accept.started += Accept;
        _inputPlayerActions.Interactions.Reject.started += Decline;
        _inputPlayerActions.Interactions.CloseMenu.started += CloseMenu;
    }
    
    private void OnDisable()
    {
        _inputPlayerActions.Interactions.Accept.started -= Accept;
        _inputPlayerActions.Interactions.Reject.started -= Decline;
        _inputPlayerActions.Interactions.CloseMenu.started -= CloseMenu;
    }

    public void HandleInputs(bool isActive)
    {
        if (isActive)
        {
            _inputPlayerActions.Interactions.Enable();
        }
        else
        {
            _inputPlayerActions.Interactions.Disable();
        }
    }

    private void CloseMenu(InputAction.CallbackContext obj)
    {
        onClose?.Invoke();
    }

    private void Decline(InputAction.CallbackContext obj)
    {
        onDecline?.Invoke();
    }

    private void Accept(InputAction.CallbackContext obj)
    {
        onAcceopt?.Invoke();
    }
    

}
