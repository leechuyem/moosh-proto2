﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private void OnMouseUp() {
        GetComponent<GoToNextSceneBehaviour>().goToNextScene(); 
    }
}
