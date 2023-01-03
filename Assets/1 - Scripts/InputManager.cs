using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
  public PlayerShipShooter playerShipShooter;
  public PlayerShipMovement playerShipMovement;

  public void Shoot(InputAction.CallbackContext context)
  {
    if (context.action.phase == InputActionPhase.Started)
      playerShipShooter.Shoot();
  }

  public void Left(InputAction.CallbackContext context)
  {
    if (context.action.phase == InputActionPhase.Started)
      playerShipMovement.SetLeft(true);
    if (context.action.phase == InputActionPhase.Canceled)
      playerShipMovement.SetLeft(false);
  }

  public void Right(InputAction.CallbackContext context)
  {
    if (context.action.phase == InputActionPhase.Started)
      playerShipMovement.SetRight(true);
    if (context.action.phase == InputActionPhase.Canceled)
      playerShipMovement.SetRight(false);
  }
}
