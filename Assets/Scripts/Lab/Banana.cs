using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Weapon
{
    [SerializeField] private float speed;

    public override void Move()
    {
        Debug.Log($"{this.name} moves with constant speed using Transform");
    }
    public override void OnHitWith(Character player)
    {
        Console.WriteLine($"{this.name}: Overriding OnHitWith(Character) ");
    }
    private void Start()
    {
        Damage = 30;
        speed = 4;
        Move();
    }
}
