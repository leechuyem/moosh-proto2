using UnityEngine;
using System.Linq; 

public class BlenderTriggerHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        int collidedFoodId = other.GetComponent<FoodData>().id;
        int index = Global.inBlenderFoods.FindIndex(bf => bf.foodId == collidedFoodId);

        if(index > -1) {
            Global.inBlenderFoods[index].addOneToQuantity(); 
        } else {
            InteractiveFood ibf = new InteractiveFood();
            ibf.foodId = collidedFoodId;
            Global.inBlenderFoods.Add(ibf); 
        }
        
        other.GetComponent<FoodData>().addedToListAlready = true; 

        other.GetComponent<DraggableFoodController>().isScaledDown = true; 
        
        Bounds bounds = gameObject.GetComponent<PolygonCollider2D>().bounds; 
        other.GetComponent<DraggableFoodController>().moveObjectToCenterOfBlender(bounds);
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        int collidedFoodId = other.GetComponent<FoodData>().id;
        int index = Global.inBlenderFoods.FindIndex(bf => bf.foodId == collidedFoodId);
        
        Global.inBlenderFoods[index].minusOneFromQuanity();            
        
        if(Global.inBlenderFoods[index].quantity == 0) {
            Global.inBlenderFoods.RemoveAt(index);
        }

        other.GetComponent<FoodData>().addedToListAlready = false; 

        other.GetComponent<DraggableFoodController>().isScaledDown = false; 

    }
}