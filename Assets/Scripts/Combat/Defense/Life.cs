using System;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int MaxHealth { get; set; }
    public int StartHealth;
    public GameObject ObjectToKillOnDeath;
    public bool DestroyOnDeath = true;

    public event Action Death;
    public event Action<int> LifeChanged;

    private int _health;
    private int _lastHealth;

    public int Health
    {
        get { return _health; }
        set { _health = Mathf.Clamp(value, 0, MaxHealth); }
    }

    void Start()
    {
        MaxHealth = StartHealth;
        Health = StartHealth;
        _lastHealth = Health;
    }

    void Update()
    {
        DidLifeChange();
        ShouldDie();
    }

    void DidLifeChange()
    {
        if (Health != _lastHealth)
        {
            if (LifeChanged != null)
            {
                LifeChanged(Health - _lastHealth);
            }
        }

        _lastHealth = _health;
    }

    void ShouldDie()
    {
        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (Death != null)
        {
            Death();
        }
        if (DestroyOnDeath)
        {
            if (ObjectToKillOnDeath != null)
            {
                Destroy(ObjectToKillOnDeath);
            }

            Destroy(gameObject);
        }
        Destroy(this);
    }

    public void SetHealth(int health)
    {
        MaxHealth = health;
        Health = health;
    }
}