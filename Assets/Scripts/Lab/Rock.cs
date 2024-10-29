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
        Debug.Log("Rock moves with RigidBody:force.");
    }
    public override void OnHitWith(Character player)
    {
        Console.WriteLine($"{this.name}: Overriding OnHitWith(Character) ");
    }
    private void Start()
    {
        Damage = 40;
        Move();
    }
}
