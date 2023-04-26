using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
  [RequireComponent(typeof(SpriteRenderer))]
  public class Manager : MonoBehaviour
  {
    #region Members
    private SpriteRenderer spriteRenderer;
    #endregion

    #region Monobehaviour Methods
    private void Start()
    {
      // Display Hello Message
      French.HelloWorld.instance.RequestDisplayHelloMessage();

      // Change color of sprite renderer
      spriteRenderer = GetComponent<SpriteRenderer>();
      spriteRenderer.color = Color.green;
    }
    #endregion
  }
}

