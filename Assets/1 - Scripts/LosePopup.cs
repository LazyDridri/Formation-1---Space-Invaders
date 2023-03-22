using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePopup : MonoBehaviour
{
  public void Retry()
  {
    SceneManager.LoadScene("Game");
  }

  public void GoMainMenu()
  {
    SceneManager.LoadScene("Main Menu");
  }
}
