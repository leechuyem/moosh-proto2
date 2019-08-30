using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForGardenDuplicates : MonoBehaviour
{
    public static CheckForGardenDuplicates instance; 

    private void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(this.gameObject);
            return; 
        }
    }
}