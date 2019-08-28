using System.Collections.Generic;

[System.Serializable]
public class Food
{
    public int id;
    public string name;
    public int sugarContent; 
    public string categoryName; 
    public string locationName; 
}

[System.Serializable]
public class Foods {
    public List<Food> FoodList;
}