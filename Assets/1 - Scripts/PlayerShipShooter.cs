using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipShooter : MonoBehaviour
{
  public GameObject prefabPlayerShipBullet;

  private bool canAttack = true;

  public void Shoot()
  {
    if (canAttack)
      Instantiate(prefabPlayerShipBullet, this.transform.position, new Quaternion());
  }

  public void SetAttack(bool value)
  {
    canAttack = value;
  }
}
