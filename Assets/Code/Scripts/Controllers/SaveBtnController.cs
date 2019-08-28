using System.Linq;
using System.Collections.Generic; 
using System.Threading.Tasks;
using UnityEngine;

public class SaveBtnController : MonoBehaviour {
    private FoodHandler foodHandler;
    private bool sendingData;
    private List<InteractiveFood> selectedFoods;
    private List<InteractiveFood> inBlenderFoods; 
    private void Start () {
        foodHandler = new FoodHandler ();
        sendingData = false;
    }
    private async void OnMouseDown () {
        if (!sendingData) {
            sendingData = true;
            await sendDataToAPI ();
            sendingData = false;
        }
    }

    private async Task sendDataToAPI () {
        // update selected food
        Task<Response>[] updateSelectedFoodTasks = foodHandler.updateSelectedFood ();
        // post selected food
        Task<Response>[] postSelectedFoodTasks = foodHandler.postSelectedFood ();

        // update inBlenderFood
        Task<Response>[] updateInBlenderFoodsTasks = foodHandler.updateInBlenderFood ();

        // post inBlenderFood
        Task<Response>[] postInBlenderFoodsTasks = foodHandler.postInBlenderFood ();

        Task<Response>[] allTasks = updateSelectedFoodTasks
                                    .Concat (postSelectedFoodTasks)
                                    .Concat (updateInBlenderFoodsTasks)
                                    .Concat (postInBlenderFoodsTasks)
                                    .ToArray ();

        await Task.WhenAll (allTasks);
    }
}