using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
  public PlayerShipShooter playerShipShooter;

  public void Shoot(InputAction.CallbackContext context)
  {
    if (context.action.phase == InputActionPhase.Started)
      playerShipShooter.Shoot();
  }
}
