using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupermarketFoodController : MonoBehaviour
{
    void Start()
    {
        GetComponent<LoadFoodFromAPIHandler>().spawnSelectedFood(); 
    }
}
