using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;
    
    [Header("Movement")]
    public int moveSpeed;
    public string playerName;
    public int playerWins;
    public int playerMoney;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
