using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomiseBtnController : MonoBehaviour
{
    public Color offColour;
    public Color onHoverColour;  
    public Color onColour; 
    public GameObject customiseController; 
    public CustomiseOptions option;  
    private bool isOn; 

    private void Start() {
        if(option == CustomiseOptions.TOP) {
            isOn = true; 
            setColour(onColour); 
        } else {
            isOn = false;
            setColour(offColour); 
        }
    }

    private void Update() {
        if(Input.GetMouseButton(0)) {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(pos, new Vector2(0,0), 0.01f);
            for(int i = 0; i < hits.Length; i++) {
                if(hits[i].collider.tag == "customiseBtn") {
                    if(hits[i].collider.gameObject == this.gameObject) {
                        isOn = true; 
                        break;
                    } else {
                        isOn = false; 
                        setColour(offColour);
                    }
                }
            }
        }
    }

    private void OnMouseEnter() {
        if(!isOn) {
            setColour(onHoverColour);
        }
    }

    private void OnMouseDown() {
        setColour(onColour);
        setOption(); 
        print(option);
    }

    private void OnMouseExit() {
        if(!isOn) {
            setColour(offColour);
        }
    }

    private void setColour(Color colour) {
        GameObject firstChild = transform.GetChild(0).gameObject; 
        for (var i = 0; i < firstChild.transform.childCount; i++) {
            firstChild.transform.GetChild (i).transform.GetComponent<SpriteRenderer> ().color = colour;
        }
    }

    private void setOption() {
        customiseController.GetComponent<CustomiseController>().options = this.option; 
    }
}
