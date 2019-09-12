using System.Collections.Generic;
using UnityEngine;
public static class Global {
    // NOTE: Player's info
    public static string userId;
    public static string sessionId;

    // NOTE: Food Info

    /* Make sure that when player enters Supermarket, Garden and Kitchen scenes
     *  for the first time, the scene will load the food from the API
     */
    public static Dictionary<Location, bool> loadedFoodFromAPI = new Dictionary<Location, bool> () { { Location.SUPERMARKET, false }, { Location.GARDEN, false }, { Location.BLENDER, false }
    };
    public static List<Food> foodData = new List<Food> ();
    public static List<InteractiveFood> selectedFoodFromAPI = new List<InteractiveFood> ();
    public static List<InteractiveFood> selectedFoods = new List<InteractiveFood> ();
    public static List<InteractiveFood> inBlenderFoodsFromAPI = new List<InteractiveFood>(); 
    public static List<InteractiveFood> inBlenderFoods = new List<InteractiveFood> ();

    // NOTE: Results
    public static Outcome outcome;
    public static Dictionary<string, Score?> ratings = new Dictionary<string, Score?> ();

    // NOTE: Saving game objects during run time
    public static List<GameObject> kitchenDraggables = new List<GameObject> ();
    public static List<GameObject> superMarketDraggables = new List<GameObject> ();
    public static List<GameObject> gardenDraggables = new List<GameObject> ();

    // SECTION: TEST CASES

    // public static List<InteractiveFood> inBlenderFoodFromAPI = new List<InteractiveFood> () {
    //     new InteractiveFood { foodId = 11, quantity = 1 },
    //     new InteractiveFood { foodId = 13, quantity = 1 },
    //     new InteractiveFood { foodId = 19, quantity = 1 },
    // };

    // // NOTE: Test for results and spawning food into blender
    // public static List<InteractiveFood> inBlenderFoods = new List<InteractiveFood> () {
    //     new InteractiveFood { foodId = 17, quantity = 3 },
    //     new InteractiveFood { foodId = 25, quantity = 3 },
    //     new InteractiveFood { foodId = 19, quantity = 1 },
    // };

    // NOTE: Test for providing data to inBlenderFoods in calculation()
    // public static List<Food> foodData = new List<Food> () {
    //     new Food { id = 17, name = "juice", sugarContent = 16, categoryName = "sometimes" },
    //     new Food { id = 19, name = "milk", sugarContent = 0, categoryName = "dairy" },
    //     new Food { id = 21, name = "pasta", sugarContent = 0, categoryName = "grains" },
    //     new Food { id = 24, name = "rice", sugarContent = 0, categoryName = "grains" },
    //     new Food { id = 25, name = "roll", sugarContent = 0, categoryName = "grains" },
    //     new Food { id = 26, name = "soda", sugarContent = 40, categoryName = "sometimes" },
    //     new Food { id = 27, name = "steak", sugarContent = 0, categoryName = "protein" },
    //     new Food { id = 28, name = "tofu", sugarContent = 0, categoryName = "protein" },
    //     new Food { id = 30, name = "tuna", sugarContent = 0, categoryName = "protein" },
    //     new Food { id = 32, name = "yoghurt", sugarContent = 0, categoryName = "dairy" },
    //     new Food { id = 3, name = "bacon", sugarContent = 0, categoryName = "protein" },
    //     new Food { id = 5, name = "bread", sugarContent = 0, categoryName = "grains" },
    //     new Food { id = 8, name = "cereal", sugarContent = 0, categoryName = "grains" },
    //     new Food { id = 9, name = "cheese", sugarContent = 0, categoryName = "dairy" },
    //     new Food { id = 11, name = "chips", sugarContent = 0, categoryName = "sometimes" },
    //     new Food { id = 12, name = "chocobar", sugarContent = 29, categoryName = "sometimes" },
    //     new Food { id = 13, name = "cupcake", sugarContent = 25, categoryName = "sometimes" },
    //     new Food { id = 14, name = "eggs", sugarContent = 0, categoryName = "protein" },
    //     new Food { id = 16, name = "icecream", sugarContent = 26, categoryName = "sometimes" },
    // };

    // NOTE: Test for spawning fixedFoods in Kitchen, sending to API
    // public static List<InteractiveFood> selectedFoods = new List<InteractiveFood> () {
    // new InteractiveFood { foodId = 17, quantity = 3 },
    // new InteractiveFood { foodId = 19, quantity = 2 },
    // new InteractiveFood { foodId = 21, quantity = 2 },
    // new InteractiveFood { foodId = 24, quantity = 2 },
    // new InteractiveFood { foodId = 25, quantity = 3 },
    // new InteractiveFood { foodId = 26, quantity = 3 },
    // new InteractiveFood { foodId = 27, quantity = 3 },
    // new InteractiveFood { foodId = 28, quantity = 3 },
    // new InteractiveFood { foodId = 30, quantity = 3 },
    // new InteractiveFood { foodId = 32, quantity = 3 },
    // new InteractiveFood { foodId = 3, quantity = 3 },
    // new InteractiveFood { foodId = 5, quantity = 3 },
    // new InteractiveFood { foodId = 8, quantity = 3 },
    // new InteractiveFood { foodId = 9, quantity = 3 },
    // new InteractiveFood { foodId = 11, quantity = 3 },
    // new InteractiveFood { foodId = 12, quantity = 3 },
    // new InteractiveFood { foodId = 13, quantity = 3 },
    // new InteractiveFood { foodId = 14, quantity = 3 },
    // new InteractiveFood { foodId = 16, quantity = 3 },
    // };

    // public static List<InteractiveFood> selectedFoodFromAPI = new List<InteractiveFood> () {
    // new InteractiveFood { foodId = 17, quantity = 3 },
    // new InteractiveFood { foodId = 19, quantity = 10 },
    // new InteractiveFood { foodId = 21, quantity = 10 },
    // new InteractiveFood { foodId = 24, quantity = 30 },
    // new InteractiveFood { foodId = 25, quantity = 3 },
    // new InteractiveFood { foodId = 26, quantity = 3 },
    // new InteractiveFood { foodId = 27, quantity = 3 },
    // new InteractiveFood { foodId = 28, quantity = 3 },
    // new InteractiveFood { foodId = 30, quantity = 3 },
    // new InteractiveFood { foodId = 32, quantity = 3 },
    // new InteractiveFood { foodId = 3, quantity = 3 },
    // new InteractiveFood { foodId = 5, quantity = 3 },
    // new InteractiveFood { foodId = 8, quantity = 3 },
    // new InteractiveFood { foodId = 9, quantity = 3 },
    // new InteractiveFood { foodId = 11, quantity = 3 },
    // new InteractiveFood { foodId = 12, quantity = 3 },
    // new InteractiveFood { foodId = 13, quantity = 3 },
    // new InteractiveFood { foodId = 14, quantity = 3 },
    // new InteractiveFood { foodId = 16, quantity = 3 },
    // };
}