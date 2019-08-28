using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetIconSpr : MonoBehaviour
{
    public string ratedCategory; 
    public Score iconScore; 
    public Sprite onSprite;
    public Sprite offSprite; 
    void Start()
    {
        if(Global.ratings[ratedCategory] == iconScore) {
            GetComponent<SpriteRenderer>().sprite = onSprite;
        } else {
            GetComponent<SpriteRenderer>().sprite = offSprite; 
        }
    }
}
