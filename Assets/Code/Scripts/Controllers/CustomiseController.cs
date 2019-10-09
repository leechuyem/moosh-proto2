using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomiseController : MonoBehaviour
{
    public Color colour; 
    public CustomiseOptions options;
    public GameObject moosh; 

    public void customiseMoosh() {
        moosh.transform.GetChild((int)options).transform.GetComponent<SpriteRenderer>().color = colour; 
    } 
}