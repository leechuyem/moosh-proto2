using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleButtonHandler : MonoBehaviour
{
    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded; 
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        for(var i = 0; i < gameObject.transform.childCount; i++) {
            setSprite(gameObject.transform.GetChild(i), scene.name);
        }
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded; 
    }

    private void setSprite(Transform button, string currentSceneName) {
        CircleBtnData childData = button.transform.GetComponent<CircleBtnData>();

        if(childData.sceneName == currentSceneName) {
            button.transform.GetComponent<SpriteRenderer>().sprite = childData.blueSprite;           
        } else {
            button.transform.GetComponent<SpriteRenderer>().sprite = childData.redSprite; 
        }
    }
}