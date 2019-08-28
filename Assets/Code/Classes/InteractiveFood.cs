using System.Collections.Generic;
using UnityEngine; 

[System.Serializable]
public class InteractiveFood
{
    public string sessionId;
    public int foodId;
    public int quantity = 1;
    public void addOneToQuantity() {
        this.quantity++;
    }
    public void minusOneFromQuanity() {
        this.quantity--;
    }
}

[System.Serializable]
public class InteractiveFoods {
    public List<InteractiveFood> FoodList; 
}