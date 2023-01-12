using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
  public float speed;
  public float distanceLimit;
  public float resetOffset;

  private GameObject target;
  private State currentState;
  private Vector3 finalDirection;

  private void Update()
  {
    if (currentState == State.ATTACKING)
    {
      Vector3 direction = target.transform.position - this.transform.position;
      direction = direction.normalized;

      this.transform.position += direction * speed * Time.deltaTime;

      float distance = Vector3.Distance(target.transform.position, this.transform.position);
      if (distance <= distanceLimit)
      {
        finalDirection = direction;
        currentState = State.FINAL_ATTACK;
      }
    }
    else if (currentState == State.FINAL_ATTACK)
    {
      this.transform.position += finalDirection * speed * Time.deltaTime;
    }

  }

  public void Kill()
  {
    Destroy(this.gameObject);
  }

  public void Attack()
  {
    PlayerShip playerShip = FindObjectOfType<PlayerShip>();
    target = playerShip.gameObject;

    currentState = State.ATTACKING;
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "EnemyResetTrigger")
    {
      this.transform.position += new Vector3(0, resetOffset);

      currentState = State.ATTACKING;
    }
  }

  private enum State
  {
    IDLE,
    ATTACKING,
    FINAL_ATTACK
  }
}


