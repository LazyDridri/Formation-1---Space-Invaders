using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyShip : MonoBehaviour
{
  public float speed;
  public float distanceLimit;
  public float resetOffset;
  public int killScore;

  public State currentState { get; private set; }
  private GameObject target;
  private Vector3 finalDirection;
  private Vector3 groupPosition;

  private void Start()
  {
    groupPosition = this.transform.position;
  }

  private void Update()
  {
    if (currentState == State.IDLE)
    {
      this.transform.position = groupPosition;
    }
    else if (currentState == State.ATTACKING)
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
    else if (currentState == State.GOING_BACK)
    {
      Vector3 direction = groupPosition - this.transform.position;
      direction = direction.normalized;

      this.transform.position += direction * speed * Time.deltaTime;

      float distance = Vector3.Distance(groupPosition, this.transform.position);
      if (distance <= 0.1f)
      {
        this.transform.position = groupPosition;
        currentState = State.IDLE;
      }
    }
  }

  public void UpdateGroupPosition(Vector3 movement)
  {
    groupPosition += movement;
  }

  public void Kill()
  {
    FindObjectOfType<ScoreManager>().AddScore(killScore);

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

      currentState = State.GOING_BACK;
    }
  }

  public enum State
  {
    IDLE,
    ATTACKING,
    FINAL_ATTACK,
    GOING_BACK
  }
}


