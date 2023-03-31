using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public GameObject losePopup;

  public void Lose()
  {
    StartCoroutine(coroutine_loseAudio());
    losePopup.SetActive(true);
  }

  private IEnumerator coroutine_loseAudio()
  {
    yield return new WaitForSeconds(0.5f);
    GetComponent<AudioSource>().Play();
  }
}
