using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    [SerializeField]private int health;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }
    public Animator anim;
    public Rigidbody2D rb;

  
    public Image healthbar;

    public bool IsDead()
    {
        if (health <= 0) 
        {
            Destroy(this.gameObject);
            return true; 
        }
        else { return false; }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthbar.fillAmount = health/100.0f;
        IsDead();
        Debug.Log($"{health}");
    }

    public void Init(int newHealth)
    {
        Health = newHealth;
    }

}
