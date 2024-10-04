using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Weapon
{
    [SerializeField] private float speed; //ใส่ค่าใน Unity ใน Object Banana

    public override void Move()
    {
        Debug.Log("Banana moves with constant speed using Transform.");
    }
    public override void OnHitWith(Character player)
    {

    }
    private void Start()
    {
        //Init(30);
        //speed = 4;
        Move();
    }
}
