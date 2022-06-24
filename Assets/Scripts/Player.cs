using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : FloatingCharacter
{
    public Bullet playerBulletPrefab;
    public float damagePerFiringBullet = 0.1f;
    public Transform bulletPoint;

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

        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            spriteRenderer.flipX = desiredMovementDirection.x < 0;
        }

        if(Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            GetHarmed(enemy.damageOnTouchPerSecond * Time.fixedDeltaTime);
        }
    }

    public override void GetHarmed(float damage)
    {
        base.GetHarmed(damage);
        GameUi.Instance.SetHealthBarRatio(health / maxHealth);
    }

    private void FireBullet()
    {
        Vector3 targetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Bullet bullet = Instantiate(playerBulletPrefab);
        Vector3 direction = targetPoint - bulletPoint.transform.position;
        direction.Normalize();
        bullet.GetFired(bulletPoint.position, direction);

        GetHarmed(damagePerFiringBullet);
    }

}
