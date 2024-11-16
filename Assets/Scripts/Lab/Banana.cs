using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Weapon
{
    [SerializeField] private float speed;

    public override void Move()
    {
        //Debug.Log($"{this.name} moves with constant speed using Transform");
        float newX = transform.position.x + speed * Time.fixedDeltaTime;
        float newY = transform.position.y;
        Vector2 newPosition = new Vector2(newX, newY);
        transform.position = newPosition;
    }
    public override void OnHitWith(Character character)
    {
        //Console.WriteLine($"{this.name}: Overriding OnHitWith(Character) ");
        if (character is Enemy)
        {
            character.TakeDamage(this.Damage);
        }
    }
    private void Start()
    {
        Init(30, this.owner);
        speed = 4.0f * GetShootDirection();
    }
    private void FixedUpdate()
    {
        Move();
    }
}
