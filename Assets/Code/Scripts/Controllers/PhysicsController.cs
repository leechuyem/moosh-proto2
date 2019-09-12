using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    void Start()
    {
        Physics2D.IgnoreLayerCollision((int)Layers.FIXEDFOOD, (int)Layers.DRAGGABLEFOOD, true);
        Physics2D.IgnoreLayerCollision((int)Layers.UI, (int)Layers.DRAGGABLEFOOD, true);        
    }

}
