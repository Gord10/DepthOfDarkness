using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FloatingCharacter : MonoBehaviour
{
    public float movementSpeed = 4;
    public float health = 10;
    public SpriteRenderer spriteRenderer;
    public float damageIndicatorTime = 0.3f;

    protected Rigidbody2D rigidbody;
    protected Vector2 desiredMovementDirection;
    protected float maxHealth; //health will be assigned to this value at Awake
    protected bool isAlive = true;

    protected virtual void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        maxHealth = health;
    }

    protected virtual void FixedUpdate()
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

            //Tint the color to red
            spriteRenderer.DOKill();
            spriteRenderer.DOColor(Color.red, damageIndicatorTime).OnComplete(() => spriteRenderer.DOColor(Color.white, damageIndicatorTime));
        }
    }

    public virtual void Die()
    {
        isAlive = false;
    }
}
