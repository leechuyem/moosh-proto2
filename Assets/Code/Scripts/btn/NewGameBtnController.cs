using System.Threading.Tasks;
using UnityEngine;
using System.Collections.Generic;
using System.Linq; 

public class NewGameBtnController : MonoBehaviour
{
    private bool sendingData = false; 
    private async void OnMouseUp() {
        if(!sendingData) {
            sendingData = true; 

            await createNewSession(); 

            sendingData = false; 
        }
    }

    private async Task createNewSession() {
        string userId = Global.userId;
        string data = $"{{\"userId\": \"{userId}\", \"hasEnded\": false}}";

        Task<Response> postNewSess = HttpHandler.postReq("https://monstermoosh.azurewebsites.net/api/sessions", data);
        Task<Response> getAllFood = HttpHandler.getReq("https://monstermoosh.azurewebsites.net/api/food"); 

        Response[] responses = await Task.WhenAll(postNewSess, getAllFood);

        if((responses[0].error == null) && (responses[1].error == null)) {
            Global.sessionId = decodeSession(responses[0].data);
            Global.foodData = decodeFood(responses[1].data); 
        } else {
            return; 
        }
        
        // go to next scene
        GetComponent<GoToNextSceneBehaviour>().goToNextScene(); 
    }

    private string decodeSession(string data) {
        return JsonUtility.FromJson<Session>(data).id;
    }

    private List<Food> decodeFood(string data) {
        data = $"{{\"FoodList\":{data}}}";
        Foods decodedData = JsonUtility.FromJson<Foods>(data); 
        return decodedData.FoodList.ToList();
    }
}
