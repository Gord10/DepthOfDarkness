using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCharacter : MonoBehaviour
{
    public float movementSpeed = 4;
    protected Rigidbody2D rigidbody;
    protected Vector2 desiredMovementDirection;

    protected virtual void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = desiredMovementDirection * movementSpeed;
        rigidbody.velocity += GameManager.Instance.gravity * Vector2.down; //Apply gravity in water
    }
}
