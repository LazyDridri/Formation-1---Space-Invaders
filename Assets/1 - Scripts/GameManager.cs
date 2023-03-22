using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public GameObject losePopup;

  public void Lose()
  {
    Debug.Log("Game is lost");
    GetComponent<AudioSource>().Play();

    losePopup.SetActive(true);
  }
}
