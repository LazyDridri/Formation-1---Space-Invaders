using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test.French
{
  public class HelloWorld : MonoBehaviour
  {
    #region Inspector
    [SerializeField]
    private string playerName;
    #endregion

    #region Members
    static public HelloWorld instance;
    #endregion

    #region Monobehaviour Methods
    private void Awake()
    {
      // Set instance
      if (instance == null)
        instance = this;

      // Save player name
      PlayerPrefs.SetString(Test.Statics.playerNameSettings, playerName);
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// Display Hello Message
    /// </summary>
    public void RequestDisplayHelloMessage()
    {
      DisplayHelloMessage();
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// Displayer Hello message in the console for the player
    /// </summary>
    private void DisplayHelloMessage()
    {
      // Get playerName from PlayerPrefs
      playerName = PlayerPrefs.GetString(Test.Statics.playerNameSettings);

      // Display hello message in the console
      Debug.Log("Bonjour " + playerName);
    }
    #endregion
  }
}

