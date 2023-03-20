using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warmup1 : MonoBehaviour
{
    public bool circleisActive = false;

    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        // Here we check if isActive is true and if it is...
        if (circleisActive)
        {
            // ...then move circle right
            transform.Translate(Input.GetAxis("Horizontal"), 0, 0);
            //when moved to right type out true
            if (circleisActive)
            {
                Debug.Log("True");
            }
        }
        
        else
        {
            
        }
    }

   
}
