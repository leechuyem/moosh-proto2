using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralBtnController : MonoBehaviour
{
    private void OnMouseDown() {
        GetComponent<GoToNextSceneBehaviour>().goToNextScene(); 
    }
}
