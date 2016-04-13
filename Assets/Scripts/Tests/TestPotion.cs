using UnityEngine;

public class TestPotion : MonoBehaviour
{
    

    private Life _life;
    private int _potionHealthChange;

    void Start()
    {
        _life = GetComponent<Life>();
        _life.LifeChanged += OnLifeChanged;
        _potionHealthChange = 2;
    }

    void OnLifeChanged(int healthChanged)
    {
        if (healthChanged == _potionHealthChange)
        {
            IntegrationTest.Pass();
        }
        else
        {
            IntegrationTest.Fail();
        }
    }
}