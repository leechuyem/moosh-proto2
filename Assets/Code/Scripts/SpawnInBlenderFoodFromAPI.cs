using System.Collections.Generic;
using UnityEngine;

public class SpawnInBlenderFoodFromAPI : MonoBehaviour
{
    public GameObject draggableFoodPrefab; 
    public float minXAxis;
    public float maxXAxis;
    public float minYAxis;
    public float maxYAxis; 

    public void spawnAPIInBlenderFood() {
        if(Global.loadedFoodFromAPI[Location.BLENDER] == false) {
            for(int i = 0; i < Global.inBlenderFoods.Count; i++) {
                List<SpriteData> spriteDatas = GetComponent<CreateFixedFood>().spriteDatas;

                int index = spriteDatas.FindIndex(sprData => Helper.getIdFromSprName(sprData.sprite.name) == Global.inBlenderFoods[i].foodId); 

                if(index > -1) {

                    for(int j = 0; j < Global.inBlenderFoods[i].quantity; j++) {
                        
                        // call create draggable
                        GetComponent<CreateDraggables>().sprite = spriteDatas[index].sprite;
                        GetComponent<CreateDraggables>().scale = spriteDatas[index].scale; 

                        GameObject spawnedFood = GetComponent<CreateDraggables>().createDraggables(); 

                        float randX = Random.Range(minXAxis, maxXAxis);
                        float randY = Random.Range(minYAxis, maxYAxis);

                        spawnedFood.transform.localPosition = new Vector3(randX, randY, -3);
                    }
                }
            }
            Global.inBlenderFoods.Clear(); 
        }
        Global.loadedFoodFromAPI[Location.BLENDER] = true; 
    }
}