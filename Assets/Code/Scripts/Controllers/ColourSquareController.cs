using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourSquareController : MonoBehaviour
{
    public GameObject customiseController; 
    private void OnMouseDown() {
        Color colour = GetComponent<SpriteRenderer>().color;
        
        customiseController.GetComponent<CustomiseController>().colour = colour; 
        customiseController.GetComponent<CustomiseController>().customiseMoosh(); 
    }
}
