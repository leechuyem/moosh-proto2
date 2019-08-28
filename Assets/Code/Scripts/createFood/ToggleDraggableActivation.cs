using UnityEngine;
using UnityEngine.SceneManagement; 
using System.Linq; 

public class ToggleDraggableActivation : MonoBehaviour
{
    public string sceneName; 
    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded; 
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if(scene.name == sceneName) {

            for(int i = 0; i < transform.childCount; i++) {
                print("on load: " + i);
                
                GameObject child = transform.GetChild(i).gameObject; 
                FoodData childData = child.GetComponent<FoodData>(); 

                child.SetActive(true); 

                if(childData.addedToListAlready) {

                    if(sceneName == "S7_Kitchen") {
                        if(Global.inBlenderFoods.Count > 0) {
                            int index = Global.inBlenderFoods.FindIndex(food => food.foodId == childData.id);

                            if(index > -1) {
                                Global.inBlenderFoods[index].minusOneFromQuanity();

                                if(Global.inBlenderFoods[index].quantity == 0) {
                                    Global.inBlenderFoods.Remove(Global.inBlenderFoods[index]);
                                }
                            }
                        }
                    }  

                    if(sceneName == "S5_Supermarket") {
                        if(Global.selectedFoods.Count > 0) {
                            int index = Global.selectedFoods.FindIndex(bf => bf.foodId == childData.id); 
                            
                            if(index > -1) {
                                Global.selectedFoods[index].minusOneFromQuanity(); 
                                if(Global.selectedFoods[index].quantity == 0) {
                                    Global.selectedFoods.Remove(Global.selectedFoods[index]);
                                }
                            }
                            
                        }
                        
                    }
                }
            }
        } else {
           for(int i = 0; i < transform.childCount; i++) {
               transform.GetChild(i).gameObject.SetActive(false);
           }
        }
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded; 
    }
}