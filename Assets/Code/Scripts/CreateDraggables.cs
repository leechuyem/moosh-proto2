using UnityEngine;
using UnityEngine.SceneManagement; 

public class CreateDraggables : MonoBehaviour
{
    public GameObject draggablePrefab;
    public string parentObjName;
    public Sprite sprite;
    public float scale; 
    public GameObject createDraggables() {
        GameObject parent = GameObject.Find(parentObjName); 
        GameObject food = Instantiate(draggablePrefab, parent.transform);
        food.GetComponent<SpriteRenderer>().sprite = sprite; 
        food.transform.localScale = new Vector3(scale, scale, 1); 
        food.AddComponent<BoxCollider2D>();

        addDraggableToPersistentList(food);

        return food; 
    }

    private void addDraggableToPersistentList(GameObject draggableFood) {

        switch(SceneManager.GetActiveScene().name) {
            case "S7_Kitchen":
                Global.kitchenDraggables.Add(draggableFood);
                break;
            case "S5_Supermarket":
                Global.superMarketDraggables.Add(draggableFood); 
                break; 
        }
    }
}
