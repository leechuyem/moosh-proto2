using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableFoodController : MonoBehaviour {
    public bool isScaledDown = false;
    private Vector2 normalScale;
    private Vector2 minScale;
    private bool isMouseDown = false; 
    void Start () {
        GetComponent<FoodData> ().id = Helper.getIdFromSprName (GetComponent<SpriteRenderer> ().sprite.name);
        normalScale = transform.localScale;
        minScale = normalScale * 0.5f;
    }

    private void Update () {
        if(Input.GetMouseButton(0)) {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(pos, new Vector2(0,0), 0.01f);
            int draggableFoodCounter = 0; 
            bool collideWithThisObject = false; 

            for(int i = 0; i < hits.Length; i++) {
                if(hits[i].collider.tag == "draggableFood") {
                    draggableFoodCounter++;
                }


                if(hits[i].collider.gameObject == this.gameObject) {
                    collideWithThisObject = true; 
                }
            }
            
            if(draggableFoodCounter == 1 && collideWithThisObject) {
                this.isMouseDown = true; 
                // print("Down on on: " + this.gameObject.GetComponent<SpriteRenderer>().sprite.name);
            }
        } else {
            this.isMouseDown = false; 
        }

        if(isMouseDown) {
            transform.localScale = normalScale;
        } else if(this.isScaledDown) {
            transform.localScale = minScale; 
        } else if (!this.isScaledDown) {
            transform.localScale = normalScale;
        }
    }

    public void moveObjectToCenterOfBlender(Bounds bounds) {
        var closestPos = bounds.ClosestPoint(new Vector3(transform.position.x, transform.position.y, -6)); 
        float x; 

         
        if(closestPos.x < 1.2) {
            x = closestPos.x + 0.1f;
        } else if (closestPos.x > 1.8) {
            x = closestPos.x - 0.2f; 
        } else {
            x = closestPos.x; 
        }

        transform.localPosition = new Vector2(x, closestPos.y);
    }
}