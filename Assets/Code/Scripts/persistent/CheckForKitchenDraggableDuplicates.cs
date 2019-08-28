using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForKitchenDraggableDuplicates : MonoBehaviour
{
    public static CheckForKitchenDraggableDuplicates instance;
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
