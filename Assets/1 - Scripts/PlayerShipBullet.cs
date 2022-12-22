using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipBullet : MonoBehaviour
{
  public float speed;
  public float deathTimeSeconds;

  private void Start()
  {
    Destroy(this.gameObject, deathTimeSeconds);
  }

  private void Update()
  {
    this.transform.position += new Vector3(0, speed * Time.deltaTime);
  }
}
