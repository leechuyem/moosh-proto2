using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class LoadFoodFromAPIHandler : MonoBehaviour
{
    public float minXAxis;
    public float maxXAxis;
    public float minYAxis;
    public float maxYAxis; 
    public void spawnSelectedFood() {
        if(Global.loadedFoodFromAPI[Location.SUPERMARKET] == false) {

            // create draggables 
            List<Transform> children = GetComponentsInChildren<Transform>().ToList(); 
            children.RemoveAt(0); 

            for(int i = 0; i < Global.selectedFoods.Count; i++) {
                int index = children.FindIndex(child => Helper.getIdFromSprName(child.GetComponent<SpriteRenderer>().sprite.name) == Global.selectedFoods[i].foodId);

                if(index > -1) {          
                    for(int j = 0; j < Global.selectedFoods[i].quantity; j++) {

                        GameObject spawnedDraggableFood = children[index].GetComponent<CreateDraggables>().createDraggables(); 

                        float randX = Random.Range(minXAxis, maxXAxis);
                        float randY = Random.Range(minYAxis, maxYAxis); 

                        spawnedDraggableFood.transform.localPosition = new Vector3(randX, randY, -3);
                    }   
                }
            }

            Global.selectedFoods.Clear(); 
        }
        Global.loadedFoodFromAPI[Location.SUPERMARKET] = true;

    }
}
