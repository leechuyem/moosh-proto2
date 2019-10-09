using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourWheelController : MonoBehaviour {
    public Texture2D texture;
    public GameObject colourPicker;
    private Vector2 offset = new Vector2(); 
    private bool inRange = false; 
    public GameObject topMoosh; 

    private void OnMouseDrag () {
        setColourPickerPosition(); 
        
    }

    private void OnMouseDown() {
        setColourPickerPosition();
    }

    private void setColourPickerPosition() {
        Vector3 newPosition; 
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition);
        
        float colourWheelDiameter = GetComponent<SpriteRenderer>().bounds.size.x; 
        float radius = colourWheelDiameter / 2;
        Vector3 center = transform.localPosition;
        float distance = Vector2.Distance(mousePosition, center); 

        if(distance < radius) {
            newPosition = mousePosition;
        } else {
            Vector3 fromMouseToOrigin = mousePosition - center;
            fromMouseToOrigin = fromMouseToOrigin * (radius / distance);
            
            newPosition = center + fromMouseToOrigin;
            colourPicker.transform.position = newPosition;
        }

        colourPicker.transform.position = newPosition; 
        colourPicker.transform.position = new Vector3(colourPicker.transform.position.x, colourPicker.transform.position.y, -1);

        getColour(colourPicker.transform.position); 
    }

    private void getColour(Vector3 colourPickerPosition) {
        Color pixel_colour = texture.GetPixelBilinear (colourPickerPosition.x, colourPickerPosition.y);
        print(ColorUtility.ToHtmlStringRGBA(pixel_colour));
        
        topMoosh.GetComponent<SpriteRenderer>().color = pixel_colour; 
        
        print (pixel_colour);
    }
}