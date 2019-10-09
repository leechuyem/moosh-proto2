using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnOnHoverBehaviour : MonoBehaviour
{
    public Color originalColour;
    public Color hoverColour;  

    private void OnMouseEnter () {
        darkColour();
    }

    private void OnMouseExit () {
        for (int i = 0; i < this.gameObject.transform.childCount; i++) {
            this.gameObject.transform.GetChild (i).transform.GetComponent<SpriteRenderer> ().color = originalColour;
        }
    }

    public void darkColour() {
        for (var i = 0; i < this.gameObject.transform.childCount; i++) {
            this.gameObject.transform.GetChild (i).transform.GetComponent<SpriteRenderer> ().color = hoverColour;
        }
    }
}
