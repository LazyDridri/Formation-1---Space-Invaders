using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupAttack : MonoBehaviour
{
  public float attackPeriod;

  private List<EnemyShip> enemies;
  private float lastTimeAttack;

  private void Start()
  {
    enemies = new List<EnemyShip>(GetComponentsInChildren<EnemyShip>());
  }

  private void Update()
  {
    if (Time.time - lastTimeAttack > attackPeriod)
    {
      Attack();
      lastTimeAttack = Time.time;
    }
  }

  private void Attack()
  {
    List<EnemyShip> availableEnemies = enemies.FindAll(enemy => enemy.currentState == EnemyShip.State.IDLE);

    int random = Random.Range(0, availableEnemies.Count);

    availableEnemies[random].Attack();
  }
}
