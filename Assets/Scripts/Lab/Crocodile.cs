using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : Enemy
{
    [SerializeField]private float attackRange;
    [SerializeField]private Player player;
    [SerializeField]private float WaitTime;
    [SerializeField]private float ReloadTime;
    [SerializeField]private GameObject bullet;
    [SerializeField]private Transform spawnPoint;

    private void Start()
    {
        Init(100);
        Debug.Log("Crocodile " + Health);

        WaitTime = 0.0f;
        ReloadTime = 5.0f;
        DamageHit = 30;
        attackRange = 6;
        player = GameObject.FindObjectOfType<Player>();
    }
    private void FixedUpdate()
    {
        WaitTime += Time.fixedUnscaledTime;
        Behaviour();
    }

    public override void Behaviour()
    {
        Vector2 distance = player.transform.position - transform.position;
        if (distance.magnitude <= attackRange)
        {
            shoot();
        }
    }

    private void shoot()
    {
        if (WaitTime>= ReloadTime)
        {
            anim.SetTrigger("Shoot");
            GameObject obj = Instantiate(bullet, spawnPoint.position, Quaternion.identity);

            WaitTime = 0.0f;
        }
    }
}
