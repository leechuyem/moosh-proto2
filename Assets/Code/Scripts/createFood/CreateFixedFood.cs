using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq; 

public class CreateFixedFood : MonoBehaviour
{
    public GameObject fixedFoodPrefab; 
    public string parentObjName; 
    public string draggableParentName; 

    // SECTION: POSITIONS
    public float bottomShelfMinX;
    public float bottomShelfMaxX;
    public float bottomShelfY; 
    public float topShelfMinX;
    public float topShelfMaxX;
    public float topShelfY;  
    public float offset; 
    private bool isBottom = true; 
    private float currentXAxis;
    private float currentYAxis; 
    private bool ableToPositioned = true; 
    // !SECTION 

    public List<SpriteData> spriteDatas;

    public void createFixedFood() {
        currentXAxis = bottomShelfMinX;
        currentYAxis = bottomShelfY;  
        GameObject parentObj = GameObject.Find(parentObjName); 

            for(int i = 0; i < Global.selectedFoods.Count; i++) {
                int index = spriteDatas.FindIndex(sprData => Helper.getIdFromSprName(sprData.sprite.name) == Global.selectedFoods[i].foodId);    
                if(index > -1) {
                    GameObject fixedFood = Instantiate(fixedFoodPrefab, parentObj.transform); 

                    fixedFood.GetComponent<SpriteRenderer>().sprite = spriteDatas[index].sprite;
                    fixedFood.transform.localScale = new Vector3(spriteDatas[index].scale, spriteDatas[index].scale, 1);
                    fixedFood.AddComponent<BoxCollider2D>();

                    float height = fixedFood.GetComponent<SpriteRenderer> ().bounds.size.y;
                    float width = fixedFood.GetComponent<SpriteRenderer> ().bounds.size.x;

                    setShelf(width); 
                    positionFixedFood(fixedFood, width, height);

                    // properties for creating draggableFood
                    fixedFood.GetComponent<CreateDraggables>().parentObjName = draggableParentName;
                    fixedFood.GetComponent<CreateDraggables>().sprite = spriteDatas[index].sprite;
                    fixedFood.GetComponent<CreateDraggables>().scale = spriteDatas[index].scale;
                }         
            } 
    }

    private void setShelf(float width) {
        if(isBottom) {
            if(currentXAxis + width > bottomShelfMaxX) {
                currentXAxis = topShelfMinX;
                currentYAxis = topShelfY;

                isBottom = false; 
            }
        } else {
            if(currentXAxis + width > topShelfMaxX) {
                ableToPositioned = false; 
            }
        }
    }

    private void positionFixedFood(GameObject fixedFood, float width, float height) {
        if(ableToPositioned) {
            currentXAxis += width / 2; 
            fixedFood.transform.localPosition = new Vector3(currentXAxis, currentYAxis + height/2, -1); 
            currentXAxis += width / 2 + offset;
        } else {
            Destroy(fixedFood); 
        }
    }
}

