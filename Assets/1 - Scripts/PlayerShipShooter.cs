using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipShooter : MonoBehaviour
{
  public GameObject prefabPlayerShipBullet;

  public void Shoot()
  {
    Instantiate(prefabPlayerShipBullet, this.transform.position, new Quaternion());
  }
}
