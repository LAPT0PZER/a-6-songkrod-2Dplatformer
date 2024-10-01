using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{
    private int damageHit;
    public int DamageHit;

    public abstract void Behavior();

    private void Start()
    {
        Behavior();
    }
}
