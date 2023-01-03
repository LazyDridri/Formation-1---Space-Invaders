using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipMovement : MonoBehaviour
{
  public float speed;
  public float maxDistanceFromCenter;

  private bool left;
  private bool right;

  private void Update()
  {
    Vector3 moveVector = new Vector3();

    if (left)
      moveVector.x -= speed * Time.deltaTime;
    if (right)
      moveVector.x += speed * Time.deltaTime;

    Vector3 newPosition = this.transform.position + moveVector;
    newPosition.x = Mathf.Clamp(newPosition.x, -maxDistanceFromCenter, maxDistanceFromCenter);

    this.transform.position = newPosition;
  }

  public void SetLeft(bool value)
  {
    left = value;
  }

  public void SetRight(bool value)
  {
    right = value;
  }
}
