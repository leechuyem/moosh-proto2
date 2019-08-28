using System.Threading.Tasks;
using System.Collections.Generic; 
using UnityEngine;

public class FoodHandler
{
    public Task<Response>[] updateSelectedFood() {
        List<InteractiveFood> selectedFoodsToUpdate = Helper.joinTwoFoodListById (Global.selectedFoods, Global.selectedFoodFromAPI);
        Task<Response>[] updateSelectedFoodTasks = HttpHandler.updateFoodReq ("https://monstermoosh.azurewebsites.net/api/selectedfood", Global.sessionId, selectedFoodsToUpdate);

        return updateSelectedFoodTasks; 
    }

    public Task<Response>[] postSelectedFood() {
        List<InteractiveFood> selectedFoodsToPost = Helper.separateTwoFoodListById (Global.selectedFoods, Global.selectedFoodFromAPI);

        Task<Response>[] postSelectedFoodTasks = HttpHandler.postFoodReq ("https://monstermoosh.azurewebsites.net/api/selectedfood", Global.sessionId, selectedFoodsToPost);

        for(int i = 0; i < selectedFoodsToPost.Count; i++) {
            Global.selectedFoodFromAPI.Add(selectedFoodsToPost[i]); 
        }
        
        return postSelectedFoodTasks;
    }

    public Task<Response>[] updateInBlenderFood() {
        List<InteractiveFood> inBlenderFoodsToUpdate = Helper.joinTwoFoodListById(Global.inBlenderFoods, Global.inBlenderFoodsFromAPI); 
        
        Task<Response>[] updateInBlenderFoodsTasks = HttpHandler.updateFoodReq("https://monstermoosh.azurewebsites.net/api/foodinblender", Global.sessionId, inBlenderFoodsToUpdate); 

        return updateInBlenderFoodsTasks; 
    }

    public Task<Response>[] postInBlenderFood() {
        List<InteractiveFood> inBlenderFoodsToPost = Helper.separateTwoFoodListById(Global.inBlenderFoods, Global.inBlenderFoodsFromAPI);
        Task<Response>[] postInBlenderFoodsTasks = HttpHandler.postFoodReq("https://monstermoosh.azurewebsites.net/api/foodinblender", Global.sessionId, inBlenderFoodsToPost);

        for(int i = 0; i < inBlenderFoodsToPost.Count; i++) {
            Global.inBlenderFoodsFromAPI.Add(inBlenderFoodsToPost[i]); 
        }

        return postInBlenderFoodsTasks;
    }

    public Task<Response>[] postCookedFood() {
        Task<Response>[] postCookedFoodTasks = HttpHandler.postFoodReq ("https://monstermoosh.azurewebsites.net/api/cookedfood", Global.sessionId, Global.inBlenderFoods); 

        return postCookedFoodTasks; 
    }

    public Task<Response>[] updateEndSession() {
        Task<Response>[] endSessionTask = HttpHandler.updateEndSession("https://monstermoosh.azurewebsites.net/api/sessions/", Global.sessionId, Global.userId); 

        return endSessionTask; 
    }
}
