using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCharacter : MonoBehaviour
{
    public float movementSpeed = 4;
    public float health = 10;
    public SpriteRenderer spriteRenderer;

    protected Rigidbody2D rigidbody;
    protected Vector2 desiredMovementDirection;
    protected float maxHealth; //health will be assigned to this value at Awake
    protected bool isAlive = true;

    protected virtual void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        maxHealth = health;
    }

    private void FixedUpdate()
    {
        if(isAlive)
        {
            rigidbody.velocity = desiredMovementDirection * movementSpeed; //Character can move to desired movement only if they are alive
        }
        
        rigidbody.velocity += GameManager.Instance.gravity * Vector2.down; //Apply gravity in water
    }

    public virtual void GetHarmed(float damage)
    {
        if(isAlive)
        {
            health -= damage;
            if (health <= 0f)
            {
                Die();
            }
        }
    }

    public virtual void Die()
    {
        isAlive = false;
    }
}
