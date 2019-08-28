using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActiveGameobject : MonoBehaviour
{
    public GameObject[] gameObjectsToDeactivate; 
    // Start is called before the first frame update
    void Start()
    {
        for(var i = 0; i < gameObjectsToDeactivate.Length; i++) {
            gameObjectsToDeactivate[i].SetActive(false);
        }
    }
}
