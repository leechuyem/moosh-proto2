using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedFoodController : MonoBehaviour
{
    private void Start() {
        GetComponent<FoodData>().id = Helper.getIdFromSprName(GetComponent<SpriteRenderer>().sprite.name); 
    }
    private void OnMouseDown() {
        GameObject spawnedDraggableFood = GetComponent<CreateDraggables>().createDraggables(); 

        spawnedDraggableFood.GetComponent<dragAndDropBehaviour>().createdFromClick = true; 

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition);
        spawnedDraggableFood.transform.position = mousePosition;  
    }
}
