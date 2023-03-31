using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipShooter : MonoBehaviour
{
  public GameObject prefabPlayerShipBullet;
  public AudioClip shootSound;
  public float shootTempo;

  private bool canAttack = true;

  public void Shoot()
  {
    if (canAttack)
    {
      Instantiate(prefabPlayerShipBullet, this.transform.position, new Quaternion());

      GetComponent<AudioSource>().PlayOneShot(shootSound);

      canAttack = false;
      StartCoroutine(coroutine_ShootTempo());
    }

  }

  public void SetAttack(bool value)
  {
    canAttack = value;
  }

  private IEnumerator coroutine_ShootTempo()
  {
    yield return new WaitForSeconds(shootTempo);
    canAttack = true;
  }
}
