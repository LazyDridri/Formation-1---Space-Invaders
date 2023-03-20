using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
  public TMP_Text textScore;
  public int scoreNewLife;
  public TMP_Text textBestScore;

  private int currentScore;
  private int currentBestScore;

  private void Start()
  {
    currentScore = 0;
    textScore.text = currentScore.ToString();

    if (!PlayerPrefs.HasKey("Best Score"))
      PlayerPrefs.SetInt("Best Score", 0);
    currentBestScore = PlayerPrefs.GetInt("Best Score");

    UpdateBestScore();
  }

  public void AddScore(int value)
  {
    int newScore = currentScore + value;
    if (newScore / scoreNewLife > currentScore / scoreNewLife)
      FindObjectOfType<LifeManager>().AddLife();

    currentScore += value;
    textScore.text = currentScore.ToString();

    if (currentScore > currentBestScore)
    {
      currentBestScore = currentScore;
      UpdateBestScore();
    }
  }

  private void UpdateBestScore()
  {
    textBestScore.text = currentBestScore.ToString();
    PlayerPrefs.SetInt("Best Score", currentBestScore);
  }
}
