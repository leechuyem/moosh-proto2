using System; 
using System.Collections.Generic; 
using System.Linq; 
public static class Helper {
    public static int getIdFromSprName(string name) {
        string id = name.Split('_')[0]; 
        return int.Parse(id);  
    }

    public static List<InteractiveFood> joinTwoFoodListById(List<InteractiveFood> listToGetElementFrom, List<InteractiveFood> listToCompare) {
        return listToGetElementFrom
                .Where(item1 => listToCompare.Any(item2 => item2.foodId == item1.foodId))
                .ToList(); 
    }

    public static List<InteractiveFood> separateTwoFoodListById(List<InteractiveFood> listToGetElementFrom, List<InteractiveFood> listToCompare) {
        return listToGetElementFrom
                .Where(item1 => !(listToCompare.Any(item2 => item2.foodId == item1.foodId)))
                .ToList(); 
    }
}
