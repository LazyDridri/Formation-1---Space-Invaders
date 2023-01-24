using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
  public int initialLifeNumber;

  private int currentLifeNumber;

  private void Start()
  {
    currentLifeNumber = initialLifeNumber;
  }

  public int LoseLife()
  {
    currentLifeNumber--;

    if (currentLifeNumber < 0)
      FindObjectOfType<GameManager>().Lose();

    return currentLifeNumber;
  }
}
