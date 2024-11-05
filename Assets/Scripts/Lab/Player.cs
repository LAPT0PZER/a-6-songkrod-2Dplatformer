using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Player : Character, IShootable
{
    [field: SerializeField]
    private Transform spawnPoint;
    public Transform SpawnPoint { get { return spawnPoint; } set { spawnPoint = value; } }
    [field: SerializeField]
    private GameObject bullet;
    public GameObject Bullet { get { return bullet; } set { bullet = value; } }

    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }
    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && WaitTime >= ReloadTime)
        {
            GameObject obj = Instantiate(bullet, spawnPoint.position, Quaternion.identity);
            Banana bananaScript = obj.GetComponent<Banana>();
            bananaScript.Init(10, this);

            WaitTime = 0;
        }
    }

    public void OnHitWith(Enemy enemy)
    {
        TakeDamage(enemy.DamageHit);
    }

    void Start()
    {
        Init(100);
        WaitTime = 0.0f;
        ReloadTime = 1.0f;
    }
    void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
    }
    void Update()
    {
        Shoot();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            OnHitWith(enemy);
        }
    }

}
