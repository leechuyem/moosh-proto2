using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnFoodFromAPI : MonoBehaviour
{
    public float minXAxis;
    public float maxXAxis;
    public float minYAxis;
    public float maxYAxis; 
    public void spawnSelectedFood() {
        if(Global.loadedFoodFromAPI[Location.GARDEN] == false) {

            // create draggables 
            List<Transform> children = GetComponentsInChildren<Transform>().ToList(); 
            children.RemoveAt(0); 

            var selectedFoods = Global.selectedFoods; 
            List<InteractiveFood> foodToRemove = new List<InteractiveFood>(); 

            for(int i = 0; i < selectedFoods.Count; i++) {
                int index = children.FindIndex(child => Helper.getIdFromSprName(child.GetComponent<SpriteRenderer>().sprite.name) == selectedFoods[i].foodId);

                if(index > -1) {    
                    foodToRemove.Add(selectedFoods[i]);      
                    for(int j = 0; j < selectedFoods[i].quantity; j++) {

                        GameObject spawnedDraggableFood = children[index].GetComponent<CreateDraggables>().createDraggables(); 

                        float randX = Random.Range(minXAxis, maxXAxis);
                        float randY = Random.Range(minYAxis, maxYAxis); 

                        spawnedDraggableFood.transform.localPosition = new Vector3(randX, randY, -3);
                    }   
                }                
            }

            for(int i = 0; i < foodToRemove.Count; i++) {
                Global.selectedFoods.Remove(foodToRemove[i]);
            }
        }
        Global.loadedFoodFromAPI[Location.GARDEN] = true;

    }
}
