using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
  public int initialLifeNumber;
  public int maxLifeNumber;

  public GameObject uiLivesParent;
  public GameObject uiLifePrefab;

  private int currentLifeNumber;

  private void Start()
  {
    currentLifeNumber = initialLifeNumber;

    for (int i = 0; i < currentLifeNumber; i++)
    {
      GameObject uiLife = Instantiate(uiLifePrefab);
      uiLife.transform.SetParent(uiLivesParent.transform);
    }
  }

  public int LoseLife()
  {
    currentLifeNumber--;

    if (currentLifeNumber < 0)
      FindObjectOfType<GameManager>().Lose();
    else
      Destroy(uiLivesParent.transform.GetChild(currentLifeNumber).gameObject);

    return currentLifeNumber;
  }

  public void AddLife()
  {
    if (currentLifeNumber < maxLifeNumber)
    {
      currentLifeNumber++;
      GetComponent<AudioSource>().Play();
      GameObject uiLife = Instantiate(uiLifePrefab);
      uiLife.transform.SetParent(uiLivesParent.transform);
    }
  }
}
