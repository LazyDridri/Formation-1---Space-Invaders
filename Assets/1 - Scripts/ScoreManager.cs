using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
  public TMP_Text textScore;

  private int currentScore;

  private void Start()
  {
    currentScore = 0;
    textScore.text = currentScore.ToString();
  }

  public void AddScore(int value)
  {
    currentScore += value;
    textScore.text = currentScore.ToString();
  }
}
