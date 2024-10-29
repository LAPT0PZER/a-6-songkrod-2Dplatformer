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
            Instantiate(bullet, spawnPoint.position, Quaternion.identity);
        }
    }

    public void OnHitWith(Enemy enemy)
    {

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
        Shoot();
    }
}
