using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMooshBtnController : MonoBehaviour
{
    private void OnMouseUp() {
        GetComponent<GoToNextSceneBehaviour>().goToNextScene(); 
    }
}
