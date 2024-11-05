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
    public IShootable owner;

    public abstract void OnHitWith(Character character);

    public abstract void Move();

    public void Init(int _damage, IShootable _Owner)
    {
        Damage = _damage;
        owner = _Owner;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnHitWith(other.GetComponent<Character>());
        Destroy(this.gameObject, 5f);
        
    }

    public int GetShootDirection()
    {
        float shootDir = owner.SpawnPoint.position.x - owner.SpawnPoint.parent.position.x;
        if (shootDir > 0)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
}
