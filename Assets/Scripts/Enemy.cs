using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : FloatingCharacter
{
    public float damageOnTouchPerSecond = 1f;
    protected Player player;

    protected override void Awake()
    {
        base.Awake();
        player = FindObjectOfType<Player>();
    }

    protected virtual void Update()
    {
        if(isAlive && (spriteRenderer.isVisible || this is Boss))
        {
            //Follow the player
            desiredMovementDirection = player.transform.position - transform.position;
            desiredMovementDirection.Normalize();

            transform.rotation = (desiredMovementDirection.x < 0) ? Quaternion.Euler(0, 180, 0) : Quaternion.identity; 
            //spriteRenderer.flipX = desiredMovementDirection.x < 0;
        }
        else
        {
            desiredMovementDirection = Vector2.zero;
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        bool isDistantFromPlayerEnoughToRotate = Vector2.Distance(player.transform.position, transform.position) > 1f; //We don't want the enemy to rotate to player if he's too close to the player

        if (isAlive && isDistantFromPlayerEnoughToRotate)
        {
            transform.rotation = (desiredMovementDirection.x < 0) ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }
    }

    public override void Die()
    {
        base.Die();
        rigidbody.constraints = RigidbodyConstraints2D.None;
        gameObject.layer = LayerMask.NameToLayer("EnemyDead");
        spriteRenderer.gameObject.layer = gameObject.layer;
    }

}
