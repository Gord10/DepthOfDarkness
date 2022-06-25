using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public Bullet bulletPrefab;
    public float fireInterval = 0.5f;
    public Transform bulletPoint;

    public float damagePerFiringBullet = 0.1f;

    protected override void Awake()
    {
        base.Awake();
    }

    public void StartFiringAtPlayer()
    {
        InvokeRepeating("FireBullet", 0, fireInterval);
    }

    private void FireBullet()
    {
        Vector3 targetPoint = player.transform.position;
        Bullet bullet = Instantiate(bulletPrefab, BulletManager.Instance.transform);
        Vector2 direction = targetPoint - bulletPoint.transform.position;
        direction.Normalize();
        bullet.GetFired(bulletPoint.position, direction);

        GetHarmed(damagePerFiringBullet); //Firing bullets harm the player
        //animator.SetTrigger("Attack");
    }

    public override void Die()
    {
        base.Die();
        CancelInvoke("FireBullet");
    }
}
