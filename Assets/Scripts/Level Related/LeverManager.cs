using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LeverManager : MonoBehaviour
{
    public event Action OnLeverTrigger;

    public void OnInteract(InputAction.CallbackContext context)
    {
        OnLeverTrigger?.Invoke();
    }
}
