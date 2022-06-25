using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : FloatingCharacter
{
    public Bullet playerBulletPrefab;
    public float damagePerFiringBullet = 0.1f;
    public Transform bulletPoint;

    [Header("Water Floating Tween Variables")]
    public float floatingTweenY = 0.02f;
    public float floatingTweenTime = 0.75f;

    private Animator animator;
    private Camera camera;

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponentInChildren<Animator>();
        camera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.transform.DOLocalMoveY(floatingTweenY, floatingTweenTime).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        //Read the input
        desiredMovementDirection.x = Input.GetAxis("Horizontal");
        desiredMovementDirection.y = Input.GetAxis("Vertical");
        desiredMovementDirection = Vector2.ClampMagnitude(desiredMovementDirection, 1f);

        bool willRotateToLeft = camera.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x;
        spriteRenderer.transform.rotation = (willRotateToLeft) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);

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
        else if(collision.gameObject.CompareTag("Surface"))
        {
            GameManager.Instance.OnPlayerTouchSurface();
        }
    }

    public override void GetHarmed(float damage)
    {
        base.GetHarmed(damage);
        GameUi.Instance.SetHealthBarRatio(health / maxHealth);
    }

    public override void Die()
    {
        base.Die();
        GameManager.Instance.OnPlayerDeath();
    }

    private void FireBullet()
    {
        Vector3 targetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Bullet bullet = Instantiate(playerBulletPrefab, BulletManager.Instance.transform);
        Vector2 direction = targetPoint - bulletPoint.transform.position;
        direction.Normalize();
        bullet.GetFired(bulletPoint.position, direction);

        GetHarmed(damagePerFiringBullet); //Firing bullets harm the player
        animator.SetTrigger("Attack");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Pearl"))
        {
            Pearl pearl = collision.gameObject.GetComponent<Pearl>();
            pearl.GetCollected();
            
        }
    }

}
