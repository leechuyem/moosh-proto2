using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CircleBtnHover : MonoBehaviour {
    private CircleBtnData btnData;

    private void Start() {
        btnData = GetComponent<CircleBtnData>();
    }

    private void OnMouseEnter () {
        setSpriteAndScale(btnData.darkRedSprite, btnData.darkRedScale); 
    }

    private void OnMouseExit() {
        setSpriteAndScale(btnData.redSprite, btnData.redScale); 
    }

    private void OnMouseDown() {
        if(GetComponent<SpriteRenderer>().sprite != btnData.blueSprite) {
            SceneManager.LoadScene (btnData.sceneName);
        }
    }

    private void setSpriteAndScale(Sprite newSprite, float newScale) {
        if(GetComponent<SpriteRenderer>().sprite != btnData.blueSprite) {
            GetComponent<SpriteRenderer>().sprite = newSprite;
            transform.localScale = new Vector3(newScale, newScale, 1); 
        }
    }
}