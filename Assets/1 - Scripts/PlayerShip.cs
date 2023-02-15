using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
  public float respawnTimer;

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "EnemyShip")
    {
      EnemyShip enemyShip = other.gameObject.GetComponent<EnemyShip>();
      enemyShip.Kill();

      this.Kill();
    }
  }

  private void Kill()
  {
    GetComponent<SpriteRenderer>().enabled = false;
    GetComponent<Collider2D>().enabled = false;

    int newLifeNumber = FindObjectOfType<LifeManager>().LoseLife();
    if (newLifeNumber >= 0)
      StartCoroutine(coroutine_Respawn());

    FindObjectOfType<EnemyGroupAttack>().SetAttack(false);
    GetComponent<PlayerShipShooter>().SetAttack(false);
  }

  private IEnumerator coroutine_Respawn()
  {
    yield return new WaitForSeconds(respawnTimer);

    GetComponent<SpriteRenderer>().enabled = true;
    GetComponent<Collider2D>().enabled = true;

    FindObjectOfType<EnemyGroupAttack>().SetAttack(true);
    GetComponent<PlayerShipShooter>().SetAttack(true);
  }
}
