using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class trolleyCollisionHandler : MonoBehaviour {
    private void OnTriggerEnter2D (Collider2D other) {
        int collidedFoodId = other.GetComponent<FoodData>().id; 
        
        int index = Global.selectedFoods.FindIndex(sf => sf.foodId == collidedFoodId);

        if(index > -1) {
            Global.selectedFoods[index].addOneToQuantity();
        } else {
            InteractiveFood sf = new InteractiveFood();
            sf.foodId = collidedFoodId;

            Global.selectedFoods.Add(sf);
        }

        other.GetComponent<FoodData>().addedToListAlready = true;
        print("total from entering trolley: " + Global.selectedFoods.Sum(item => item.quantity));

        // print(Global.selectedFoods.Find(sf => sf.foodId == collidedFoodId).foodName + " " + Global.selectedFoods.Find(sf => sf.foodId == collidedFoodId).quantity);

        // string listitems = "items: ";

        // foreach(var item in Global.selectedFoods) {
        //     listitems += item.foodName + " "; 
        // }

        // print(listitems);

        // print(Global.selectedFoods.Count);
    }

    private void OnTriggerExit2D (Collider2D other) {
        int collidedFoodId = other.GetComponent<FoodData>().id; 
        int index = Global.selectedFoods.FindIndex(sf => sf.foodId == collidedFoodId);
        
        Global.selectedFoods[index].minusOneFromQuanity();

        if(Global.selectedFoods[index].quantity == 0) {
            Global.selectedFoods.Remove(Global.selectedFoods[index]);
        }
        other.GetComponent<FoodData>().addedToListAlready = false;

        // string listitems = "items: ";

        // foreach(var item in Global.selectedFoods) {
        //     listitems += item.foodName + " "; 
        // }

        // print(listitems);
    }
}

