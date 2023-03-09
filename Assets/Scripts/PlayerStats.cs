using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }

    private int money;
    private int stackLevel = 5;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddMoney(int amount)
    {
        money += amount;
    }

    public void DeductMoney(int amount)
    {
        money -= amount;
    }

    public int GetMoney()
    {
        return money;
    }    

    public void AddStackLevel(int amount)
    {
        stackLevel += amount;
    }

    public int GetMaxStackLevel()
    {
        return stackLevel;
    }
}
