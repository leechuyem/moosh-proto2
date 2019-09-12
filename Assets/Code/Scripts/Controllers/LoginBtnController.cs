using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginBtnController : MonoBehaviour
{
    private void OnMouseUp() {
        GetComponent<InputHandler>().login(); 
    }
}
