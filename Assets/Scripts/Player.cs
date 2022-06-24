using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : FloatingCharacter
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Read the input
        desiredMovementDirection.x = Input.GetAxis("Horizontal");
        desiredMovementDirection.y = Input.GetAxis("Vertical");
        desiredMovementDirection = Vector2.ClampMagnitude(desiredMovementDirection, 1f);
    }
}
