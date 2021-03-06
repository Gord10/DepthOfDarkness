using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2;
    public float damage = 2.5f;
    public bool isPlayerBullet = true;

    private Rigidbody2D rigidbody;
    private Vector2 direction;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void GetFired(Vector3 startPos, Vector2 direction)
    {
        transform.position = startPos;
        this.direction = direction;
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = direction * speed;
        //print(rigidbody.velocity.magnitude);
        rigidbody.velocity += GameManager.Instance.gravity * Vector2.down;
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && isPlayerBullet) //Harm enemy
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.GetHarmed(damage);
            GameManager.Instance.OnPlayerHarmAnyone(); //Player has harmed someone
        }

        if(collision.gameObject.CompareTag("Player") && !isPlayerBullet)
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.GetHarmed(damage);
        }

        gameObject.SetActive(false);
    }


}
