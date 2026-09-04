using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class StatsUI : MonoBehaviour
{
    private bool _statsOpen;
    public GameObject statsPanel;
    public GameObject[] playerMenu;
    
    void Start()
    {
        UpdateAllStats();
        statsPanel.SetActive(false);
    }

    void Update()
    {
        if (Keyboard.current.tabKey.wasPressedThisFrame)
        {
            statsPanel.SetActive(!statsPanel.activeSelf);
        }
    }

    private void UpdateName()
    {
        playerMenu[0].GetComponentInChildren<TMP_Text>().text = "Name: " + StatsManager.Instance.playerName;
    }
    private void UpdateMoney()
    {
        playerMenu[1].GetComponentInChildren<TMP_Text>().text = "Money: " + StatsManager.Instance.playerMoney;
    }
    private void UpdateWins()
    {
        playerMenu[2].GetComponentInChildren<TMP_Text>().text = "Wins:" + StatsManager.Instance.playerWins;
    }
    
    private void UpdateInventory()
    {
        playerMenu[3].GetComponentInChildren<TMP_Text>().text = "Inventory: \n" + StatsManager.Instance.playerInventory;
    }

    private void UpdateAllStats()
    {
        UpdateName();
        UpdateMoney();
        UpdateWins();
        UpdateInventory();
    }
}
