using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : Enemy, IShootable
{
    float attackRange;
    public float AttackRange { get { return attackRange; } set { attackRange = value; } }

    public Player player;
    private Animator animator;

    [field: SerializeField]
    private Transform spawnPoint;
    public Transform SpawnPoint { get { return spawnPoint; } set {spawnPoint = value; } }
    [field: SerializeField]
    private GameObject bullet;
    public GameObject Bullet { get {return bullet; } set {bullet = value; } }

    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }

    void Start()
    {
        Init(100);
        WaitTime = 0.0f;
        ReloadTime = 5.0f;
        DamageHit = 30;
        AttackRange = 6;
        player = GameObject.FindObjectOfType<Player>();
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
        Behavior();
    }
    public override void Behavior()
    {
        Vector2 distance = player.transform.position - transform.position;
        if (distance.magnitude <= attackRange)
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        if (WaitTime >= ReloadTime)
        {
            animator.SetTrigger("Shoot");
            GameObject obj = Instantiate(Bullet, SpawnPoint.position, Quaternion.identity);
            Rock rockScript = obj.GetComponent<Rock>();
            rockScript.Init(20,this);

            WaitTime = 0;
        }
    }
}
