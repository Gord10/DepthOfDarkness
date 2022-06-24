using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : FloatingCharacter
{
    public float damageOnTouchPerSecond = 1f;
    private Player player;

    protected override void Awake()
    {
        base.Awake();
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        //Follow the player
        desiredMovementDirection = player.transform.position - transform.position;
        desiredMovementDirection.Normalize();

        spriteRenderer.flipX = desiredMovementDirection.x < 0;
    }

    public override void Die()
    {
        base.Die();
        rigidbody.constraints = RigidbodyConstraints2D.None;
        gameObject.layer = LayerMask.NameToLayer("EnemyDead");
    }

}
