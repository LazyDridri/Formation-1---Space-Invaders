using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupAttack : MonoBehaviour
{
  public float attackPeriod;

  private List<EnemyShip> enemies;
  private float lastTimeAttack;
  private bool attacking;

  private void Start()
  {
    enemies = new List<EnemyShip>(GetComponentsInChildren<EnemyShip>());
    SetAttack(true);
  }

  private void Update()
  {
    if (Time.time - lastTimeAttack > attackPeriod)
    {
      if (attacking)
        Attack();

      lastTimeAttack = Time.time;
    }
  }

  public void SetAttack(bool value)
  {
    attacking = value;
  }

  private void Attack()
  {
    List<EnemyShip> availableEnemies = enemies.FindAll(enemy => enemy.currentState == EnemyShip.State.IDLE);

    int random = Random.Range(0, availableEnemies.Count);

    if (availableEnemies[random] != null)
      availableEnemies[random].Attack();
  }
}
