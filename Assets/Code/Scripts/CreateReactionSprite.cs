using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateReactionSprite : MonoBehaviour
{
    public List<ReactionSprite> sprites; 
    void Start()
    {
        int index = sprites.FindIndex(spr => spr.outcome == Global.outcome); 

        GetComponent<SpriteRenderer>().sprite = sprites[index].sprite; 
        transform.localPosition = new Vector3(sprites[index].xAxis, sprites[index].yAxis, -1);
        transform.localScale = new Vector3(sprites[index].scale, sprites[index].scale, 1); 
    }
}
