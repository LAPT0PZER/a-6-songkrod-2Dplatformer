using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Weapon
{
    private Rigidbody2D rb2d;
    private Vector2 force;

    public override void Move()
    {
        //Debug.Log("Rock moves with RigidBody:force.");
        rb2d.AddForce(force);
    }
    public override void OnHitWith(Character character)
    {
        //Console.WriteLine($"{this.name}: Overriding OnHitWith(Character) ");
        if (character is Player)
        {
            character.TakeDamage(this.Damage);
        }
    }
    private void Start()
    {
        //Init(20, this.owner);
        force = new Vector2 (GetShootDirection() * 90, 400 );
        rb2d = GetComponent<Rigidbody2D>();
        Move();
    }
    private void Update()
    {

    }
}
