using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartBtnController : MonoBehaviour
{
    private void Start() {
        
    }
    private async void OnMouseUp() {
        clearLists(); 
        string userId = Global.userId; 

        Response sessRes = await HttpHandler.getReq("https://monstermoosh.azurewebsites.net/api/sessions/lastopensession/" + userId); 

        if(sessRes.error == null) {
            // HAS an unfinished game                
            Session lastSess = JsonUtility.FromJson<Session>(sessRes.data);
            Global.sessionId = lastSess.id;

            print("last session from restart: " + sessRes.data); 
        } else {
            print("something went wrong: " + sessRes.error);
        }

        GetComponent<GoToSpecificScene>().goToScene(); 
    }

    private void clearLists() {
        Global.sessionId = null; 

        Global.selectedFoodFromAPI.Clear();
        Global.selectedFoods.Clear();
        Global.inBlenderFoods.Clear();
        Global.inBlenderFoodsFromAPI.Clear(); 

        Global.ratings.Clear();   

        Global.kitchenDraggables.Clear();
        Global.superMarketDraggables.Clear();
        Global.gardenDraggables.Clear(); 

        Global.loadedFoodFromAPI[Location.SUPERMARKET] = false; 
        Global.loadedFoodFromAPI[Location.GARDEN] = false; 
        Global.loadedFoodFromAPI[Location.BLENDER] = false; 


        GameObject kitchenDraggableFoods = GameObject.Find("KitchenDraggableFoods"); 
        GameObject supermarketDraggableFoods = GameObject.Find("SupermarketDraggableFoods");
        GameObject gardenFoodDraggables = GameObject.Find("GardenFoodDraggables");

        Destroy(kitchenDraggableFoods);
        Destroy(supermarketDraggableFoods);
        Destroy(gardenFoodDraggables);
    }
}
