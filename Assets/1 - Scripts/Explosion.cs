using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
  public void Kill()
  {
    Destroy(this.gameObject);
  }

  public void PlayExplosionSound()
  {
    GetComponent<AudioSource>().Play();
  }
}
