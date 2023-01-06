using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
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
    Destroy(this.gameObject);
  }
}
