using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenFoodController : MonoBehaviour
{
    void Start()
    {
        GetComponent<CreateFixedFood>().createFixedFood(); 

        // create this from the api (ONLY ONCE);
        GetComponent<SpawnInBlenderFoodFromAPI>().spawnAPIInBlenderFood(); 
    }
}
