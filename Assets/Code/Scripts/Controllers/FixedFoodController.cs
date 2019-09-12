using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedFoodController : MonoBehaviour
{
    private void Start() {
        GetComponent<FoodData>().id = Helper.getIdFromSprName(GetComponent<SpriteRenderer>().sprite.name); 

        if(GetComponent<CreateNameTags>()) {
            float width = GetComponent<SpriteRenderer>().bounds.size.x; 
            float height = GetComponent<SpriteRenderer>().bounds.size.y; 
            float x = transform.localPosition.x; 
            float y = transform.localPosition.y - height / 2; 

            GetComponent<CreateNameTags>().createTag(gameObject.name.ToUpper(), x, y);
        }
    }
    private void OnMouseDown() {
        GameObject spawnedDraggableFood = GetComponent<CreateDraggables>().createDraggables(); 

        spawnedDraggableFood.GetComponent<dragAndDropBehaviour>().createdFromClick = true; 

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition);
        spawnedDraggableFood.transform.position = mousePosition;  
    }
}
