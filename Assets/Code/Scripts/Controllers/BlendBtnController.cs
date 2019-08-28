using System;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class BlendBtnController : MonoBehaviour {
    public Sprite redSprite;
    public Sprite greenSprite;
    public GameObject buttonToEnableAfterCalculation; 
    private FoodHandler foodHandler;

    private void Start() {
        foodHandler = new FoodHandler(); 
    }
    private void OnMouseUp () {
        /* Post Global.selectedFoods to /api/selectedFood
         * Update Global.selectedFoodsFromAPI to /api/selectedFood
         * Post Global.inBlenderFoods to /api/cookedFood
         */ 
        sendDataToAPI();

        // change the blender button sprite to red
        GetComponent<SpriteRenderer> ().sprite = redSprite;

        // Calculation
        GetComponent<Calculations>().calc(); 

        // change the blender button sprite to green
        GetComponent<SpriteRenderer>().sprite = greenSprite; 

        // enable the Feed Moosh Button
        enableFeedMooshBtn();
    }

    private void enableFeedMooshBtn () {
        buttonToEnableAfterCalculation.SetActive(true);
    }

    private async void sendDataToAPI() {
        Task<Response>[] updateSelectedFoodTasks = foodHandler.updateSelectedFood(); 
        Task<Response>[] postSelectedFoodTasks = foodHandler.postSelectedFood(); 
        Task<Response>[] postCookedFoodTasks = foodHandler.postCookedFood(); 
        Task<Response>[] sendEndSessionTasks = foodHandler.updateEndSession(); 
        
        Task<Response>[] allTasks = updateSelectedFoodTasks
                                    .Concat(postSelectedFoodTasks)
                                    .Concat(postCookedFoodTasks)
                                    .Concat(sendEndSessionTasks)
                                    .ToArray(); 

        await Task.WhenAll(allTasks); 
    }
}