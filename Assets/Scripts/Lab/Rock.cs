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
        rb2d.AddForce(force, ForceMode2D.Impulse);
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
        Damage = 20;
        force = new Vector2 (GetShootDirection() * 90, 400 );
        Move();
    }
    private void Update()
    {

    }
}
