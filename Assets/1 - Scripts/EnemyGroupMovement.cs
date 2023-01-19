using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupMovement : MonoBehaviour
{
  public float movingTempo;
  public float horizontalMovement;
  public float verticalMovement;
  public float maxDistanceFromCenter;

  private EnemyShip[] enemies;
  private float lastTimeMoving;
  private bool goingRight;
  private float distanceFromCenter;

  private void Start()
  {
    enemies = GetComponentsInChildren<EnemyShip>();
  }

  private void Update()
  {
    if (Time.time - lastTimeMoving > movingTempo)
    {
      if (goingRight)
      {
        if (distanceFromCenter > maxDistanceFromCenter)
        {
          Move(new Vector3(0, -verticalMovement));
          goingRight = false;
        }
        else
        {
          Move(new Vector3(horizontalMovement, 0));
          distanceFromCenter += horizontalMovement;
        }
      }
      else
      {
        if (distanceFromCenter < -maxDistanceFromCenter)
        {
          Move(new Vector3(0, -verticalMovement));
          goingRight = true;
        }
        else
        {
          Move(new Vector3(-horizontalMovement, 0));
          distanceFromCenter -= horizontalMovement;
        }
      }

      lastTimeMoving = Time.time;
    }
  }

  private void Move(Vector3 movement)
  {
    foreach (EnemyShip enemy in enemies)
    {
      if (enemy != null)
      {
        enemy.UpdateGroupPosition(movement);
      }
    }
  }
}
