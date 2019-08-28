using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Calculations : MonoBehaviour {
    private Dictionary<string, int> categoryDict = new Dictionary<string, int> () { 
        { "vegetables", 0 }, 
        { "fruit", 0 }, 
        { "grains", 0 }, 
        { "protein", 0 }, 
        { "dairy", 0 }, 
        { "sometimes", 0 }, 
        { "water", 0 },
    };
    private Dictionary<string, double> categoryRatioDict = new Dictionary<string, double> () { 
        { "vegetables", 0 }, 
        { "fruit", 0 }, 
        { "grains", 0 }, 
        { "protein", 0 }, 
        { "dairy", 0 }
    };
    private Dictionary<string, Score?> categoryScoreDict = new Dictionary<string, Score?> () { 
        { "vegetables", null }, 
        { "fruit", null }, 
        { "grains", null }, 
        { "protein", null }, 
        { "dairy", null },
    };
    private Dictionary<string, Score?> generalisedScoreDict = new Dictionary<string, Score?> () { 
        { "portion", null }, 
        { "sugar", null }, 
        { "water", null },
    };

    private double totalItems;
    private List<InteractiveFood> sometimesFood = new List<InteractiveFood> ();

    private Score balance;

    public void calc () {
        sumCategories ();
        getTotalItems ();
        calcCategoryRatio ();

        // small icon in RESULT scene
        rateCategoryScore ();

        // SUPER BIG icon in RESULT scene 
        rateBalance ();

        // Medium icon in RESULT scene
        ratePortion ();
        rateSugar ();
        rateWater ();

        // Reaction
        storeOutcome(); 
        storeRatings ();
    }

    private void sumCategories () {
        for (var i = 0; i < Global.inBlenderFoods.Count; i++) {

            InteractiveFood currentFood = Global.inBlenderFoods[i];

            int index = Global.foodData.FindIndex (data => data.id == currentFood.foodId);

            if (index > -1) {
                string currentCategory = Global.foodData[index].categoryName;
                categoryDict[currentCategory] += currentFood.quantity;
            }
        }
    }

    private void getTotalItems () {
        for (int i = 0; i < categoryDict.Count; i++) {
            var element = categoryDict.ElementAt (i);
            totalItems += element.Value;
        }
        print ("total items: " + totalItems);
    }

    private void calcCategoryRatio () {
        for (int i = 0; i < categoryRatioDict.Count; i++) {
            var item = categoryRatioDict.ElementAt (i);
            string category = item.Key;

            categoryRatioDict[category] = System.Math.Round ((categoryDict[category] / totalItems) * 7);

            print (category + " ratio: " + categoryRatioDict[category]);
        }
    }

    private void rateCategoryScore () {
        categoryScoreDict["vegetables"] = targetTwoRatio (categoryRatioDict["vegetables"]);
        categoryScoreDict["fruit"] = targetOneRatio (categoryRatioDict["fruit"]);
        categoryScoreDict["grains"] = targetTwoRatio (categoryRatioDict["grains"]);
        categoryScoreDict["protein"] = targetOneRatio (categoryRatioDict["protein"]);
        categoryScoreDict["dairy"] = targetOneRatio (categoryRatioDict["dairy"]);

        foreach (var item in categoryScoreDict) {
            print (item.Key + "'s score: " + item.Value);
        }
    }

    private Score targetOneRatio (double ratio) {
        if (ratio == 0) {
            return Score.LOW;
        } else if (ratio == 1) {
            return Score.HIGH;
        } else if (ratio >= 2 && ratio <= 3) {
            return Score.MEDIUM;
        } else {
            return Score.LOW;
        }
    }

    private Score targetTwoRatio (double ratio) {
        if (ratio == 0) {
            return Score.LOW;
        } else if (ratio == 1) {
            return Score.MEDIUM;
        } else if (ratio == 2) {
            return Score.HIGH;
        } else if (ratio >= 3 && ratio <= 4) {
            return Score.MEDIUM;
        } else {
            return Score.LOW;
        }
    }

    private void rateBalance () {
        int highBalanceScore = 0;
        int mediumBalanceScore = 0;
        int lowBalanceScore = 0;

        for (int i = 0; i < categoryScoreDict.Count; i++) {
            var element = categoryScoreDict.ElementAt (i);

            switch (element.Value) {
                case Score.HIGH:
                    highBalanceScore++;
                    break;
                case Score.MEDIUM:
                    mediumBalanceScore++;
                    break;
                case Score.LOW:
                    lowBalanceScore++;
                    break;
            }
        }

        if (highBalanceScore >= 4) {
            balance = Score.HIGH;
        } else if (lowBalanceScore >= 2) {
            balance = Score.LOW;
        } else {
            balance = Score.MEDIUM;
        }

        print ("Balance Score: " + balance);
    }

    private void ratePortion () {
        if (totalItems >= 0 && totalItems <= 2) {
            generalisedScoreDict["portion"] = Score.LOW;
        } else if (totalItems >= 3 && totalItems < 5) {
            generalisedScoreDict["portion"] = Score.MEDIUM;
        } else if (totalItems >= 5 && totalItems <= 10) {
            generalisedScoreDict["portion"] = Score.HIGH;
        } else if (totalItems >= 11 && totalItems <= 13) {
            generalisedScoreDict["portion"] = Score.MEDIUM;
        } else {
            generalisedScoreDict["portion"] = Score.LOW;
        }

        print ("portion score: " + generalisedScoreDict["portion"]);
    }

    private void rateSugar () {
        int sugarTotal = 0;

        for (int i = 0; i < Global.inBlenderFoods.Count; i++) {
            InteractiveFood currentFood = Global.inBlenderFoods[i];
            int index = Global.foodData.FindIndex (data => data.id == currentFood.foodId);

            if (index > -1) {
                Food data = Global.foodData[index];

                if (data.categoryName == "sometimes") {
                    sugarTotal += data.sugarContent * currentFood.quantity;
                }
            }
        }

        if (sugarTotal <= 10) {
            generalisedScoreDict["sugar"] = Score.HIGH;
        } else if (sugarTotal <= 24) {
            generalisedScoreDict["sugar"] = Score.MEDIUM;
        } else {
            generalisedScoreDict["sugar"] = Score.LOW;
        }

        print ("sugar score: " + generalisedScoreDict["sugar"]);
    }

    private void rateWater () {
        if (categoryDict["water"] >= 0 && categoryDict["water"] <= 3) {
            generalisedScoreDict["water"] = Score.LOW;
        } else if (categoryDict["water"] >= 4 && categoryDict["water"] <= 6) {
            generalisedScoreDict["water"] = Score.MEDIUM;
        } else {
            generalisedScoreDict["water"] = Score.HIGH;
        }
    }

    private void storeRatings () {
        for (int i = 0; i < categoryScoreDict.Count; i++) {
            var element = categoryScoreDict.ElementAt (i);
            Global.ratings.Add (element.Key, element.Value);
        }

        for (int i = 0; i < generalisedScoreDict.Count; i++) {
            var element = generalisedScoreDict.ElementAt (i);
            Global.ratings.Add (element.Key, element.Value);
        }

        Global.ratings.Add ("balance", balance);
    }

    private void storeOutcome() {
        Global.outcome = getOutcome(); 
    }

    private Outcome getOutcome () {
        // HYPER
        if (generalisedScoreDict["sugar"] == Score.LOW) {
            return Outcome.HYPER;
        }

        // VOMIT
        if (totalItems >= 20) {
            return Outcome.VOMIT;
        }

        // SLEEP
        if (generalisedScoreDict["portion"] == Score.LOW) {
            return Outcome.SLEEP;
        }

        // DISCO
        if (balance == Score.HIGH &&
            categoryScoreDict["vegetables"] == Score.HIGH &&
            categoryScoreDict["fruit"] == Score.HIGH &&
            categoryScoreDict["grains"] == Score.HIGH &&
            categoryScoreDict["protein"] == Score.HIGH &&
            categoryScoreDict["dairy"] == Score.HIGH &&
            generalisedScoreDict["portion"] == Score.HIGH &&
            generalisedScoreDict["sugar"] == Score.HIGH) {
            return Outcome.DISCO;
        }

        // PARTY
        if (balance == Score.HIGH &&
            generalisedScoreDict["sugar"] == Score.HIGH &&
            generalisedScoreDict["portion"] == Score.HIGH) {
            return Outcome.PARTY;
        }

        // BROCOLLI, FART, POOP, EGG, COW, SLEEP
        var sortedDict = from category in categoryRatioDict
        orderby category.Value descending
        select category;

        switch (sortedDict.ElementAt (0).Key) {
            case "vegetables":
                return Outcome.BROCOLLI;
            case "fruit":
                return Outcome.FART;
            case "grains":
                return Outcome.POOP;
            case "protein":
                return Outcome.EGG;
            case "dairy":
                return Outcome.COW;
        }

        return Outcome.SLEEP;
    }
}