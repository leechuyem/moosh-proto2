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
        sendDataToAPI();
        GetComponent<SpriteRenderer> ().sprite = redSprite;
        GetComponent<Calculations>().calc(); 
        GetComponent<SpriteRenderer>().sprite = greenSprite; 
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