using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : Enemy
{
    private float attackRange;
    private Player player;

    private void Start()
    {
        Init(100);
        Debug.Log("Crocodile " + Health);

        Behaviour();
    }

    public override void Behaviour()
    {
        Debug.Log("Crocodile");
    }
}
