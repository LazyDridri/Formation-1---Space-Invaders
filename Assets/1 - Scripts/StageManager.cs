using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageManager : MonoBehaviour
{
  public GameObject prefabEnemyGroup;
  public float timeDisplayUI;
  public TMP_Text textStage;

  private int currentStage = 0;
  private GameObject currentEnemyGroup;

  private void Start()
  {
    StartCoroutine(coroutine_DisplayUI());
  }

  private void Update()
  {
    if (currentEnemyGroup)
    {
      int enemiesNumber = currentEnemyGroup.transform.childCount;
      if (enemiesNumber == 0)
      {
        Destroy(currentEnemyGroup);
        StartCoroutine(coroutine_DisplayUI());
      }
    }
  }

  private IEnumerator coroutine_DisplayUI()
  {
    currentStage++;
    textStage.text = "Stage " + currentStage.ToString();
    textStage.gameObject.SetActive(true);

    yield return new WaitForSeconds(timeDisplayUI);

    textStage.gameObject.SetActive(false);

    currentEnemyGroup = Instantiate(prefabEnemyGroup);
    currentEnemyGroup.transform.SetParent(this.transform);
  }
}
