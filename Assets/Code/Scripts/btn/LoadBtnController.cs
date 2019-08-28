using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq; 

public class LoadBtnController : MonoBehaviour
{
    private bool gettingData = false; 
    private async void OnMouseUp() {
        if(!gettingData) {
            this.gettingData = true; 

            Task<Response> getSelectedFood = HttpHandler.getReq("https://monstermoosh.azurewebsites.net/api/SelectedFood/" + Global.sessionId);
            Task<Response> getInBlenderFood = HttpHandler.getReq("https://monstermoosh.azurewebsites.net/api/FoodInBlender/" + Global.sessionId);
            Task<Response> getAllFood = HttpHandler.getReq("https://monstermoosh.azurewebsites.net/api/food"); 

            Response[] responses = await Task.WhenAll(getSelectedFood, getInBlenderFood, getAllFood);

            if((responses[0].error == null) && (responses[1].error == null) && (responses[2].error == null)) {                
                Global.selectedFoodFromAPI = decodeInteractiveFood(responses[0].data);
                Global.selectedFoods = decodeInteractiveFood(responses[0].data);

                Global.inBlenderFoodsFromAPI = decodeInteractiveFood(responses[1].data);
                Global.inBlenderFoods = decodeInteractiveFood(responses[1].data);
                
                Global.foodData = decodeFood(responses[2].data); 

                // go to next scene          
                GetComponent<GoToNextSceneBehaviour>().goToNextScene(); 
            } else {
                print(responses[0].error + " - " + responses[1].error); 
                this.gettingData = false; 
                return; 
            }
        }
    }

    private List<InteractiveFood> decodeInteractiveFood(string data) {
        data = $"{{\"FoodList\":{data}}}";
        InteractiveFoods selectedFoods = JsonUtility.FromJson<InteractiveFoods>(data); 
        return selectedFoods.FoodList.ToList();
    }

    private List<Food> decodeFood(string data) {
        data = $"{{\"FoodList\":{data}}}";
        Foods decodedData = JsonUtility.FromJson<Foods>(data); 
        return decodedData.FoodList.ToList();
    }
}