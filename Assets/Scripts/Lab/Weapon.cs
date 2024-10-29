using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private int damage;
    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }
    protected IShootable shootable;
    protected string owner;
    public abstract void OnHitWith(Character character);
    public abstract void Move();
    public int GetShootDirection()
    {
        return 1;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        OnHitWith(other.GetComponent<Character>());
        Destroy(this.gameObject);
    }
    public void Init(int newDamage, string newOwner)
    {
        damage = newDamage;
        owner = newOwner;
    }
}
