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
    }

    private void OnTriggerExit2D(Collider2D other) {
        int collidedFoodId = other.GetComponent<FoodData>().id;
        int index = Global.inBlenderFoods.FindIndex(bf => bf.foodId == collidedFoodId);
        
        Global.inBlenderFoods[index].minusOneFromQuanity();            
        
        if(Global.inBlenderFoods[index].quantity == 0) {
            Global.inBlenderFoods.RemoveAt(index);
        }

        other.GetComponent<FoodData>().addedToListAlready = false; 
    }
}