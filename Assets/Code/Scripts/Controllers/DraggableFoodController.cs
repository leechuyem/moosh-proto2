using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableFoodController : MonoBehaviour
{
    void Start()
    {
        GetComponent<FoodData>().id = Helper.getIdFromSprName(GetComponent<SpriteRenderer>().sprite.name); 
    }
}
