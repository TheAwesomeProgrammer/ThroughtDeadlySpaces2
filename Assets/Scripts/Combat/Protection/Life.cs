using System;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int MaxHealth;
    public int StartHealth;

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

    void Die()
    {
        if (Death != null)
        {
            Death();
        }

        Destroy(gameObject);
    }


}