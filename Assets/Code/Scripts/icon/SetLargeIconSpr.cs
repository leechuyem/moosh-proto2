using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLargeIconSpr : MonoBehaviour
{
    public string ratedCategory; 
    public Sprite highSprite; 
    public Sprite mediumSprite;
    public Sprite lowSprite; 
    void Start()
    {
        switch(Global.ratings[ratedCategory]) {
            case Score.HIGH:
                GetComponent<SpriteRenderer>().sprite = highSprite;
                break;
            case Score.MEDIUM:
                GetComponent<SpriteRenderer>().sprite = mediumSprite;
                break;
            case Score.LOW:
                GetComponent<SpriteRenderer>().sprite = lowSprite;
                break;
        }      
    }

}
