using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenFoodController : MonoBehaviour
{
    void Start()
    {
        GetComponent<SpawnFoodFromAPI>().spawnSelectedFood(); 
    }
}
