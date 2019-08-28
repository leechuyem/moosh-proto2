using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForSupermarketDraggableDuplicates : MonoBehaviour
{
    public static CheckForSupermarketDraggableDuplicates instance;
    private void Awake() {
        if (instance == null)
         {
             instance = this;
         }
         else
         {
             Destroy(this.gameObject);
             return;
         }
    }
}
