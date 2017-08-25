using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour 
{
    public int maxPlayerHealth = 101;
    public int playerHealth = 101;
    public Text healthText;

    private GameManagerMaster gameManagerMaster;
    private PlayerManagerMaster playerManagerMaster;

    private void OnEnable()
    {
        SetInitialReferences();
        playerManagerMaster.EventPlayerHealthDeduction += DeductHealth;
        playerManagerMaster.EventPlayerHealthIncrease += IncreaseHealth;
    }

    private void OnDisable()
    {
        playerManagerMaster.EventPlayerHealthDeduction -= DeductHealth;
        playerManagerMaster.EventPlayerHealthIncrease -= IncreaseHealth;
    }

    void SetInitialReferences()
    {
        gameManagerMaster = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerMaster>();
        playerManagerMaster = GetComponent<PlayerManagerMaster>();
    }

    void DeductHealth(int healthChange)
    {
        if (gameManagerMaster.isGameOver)
            return;

        playerHealth -= healthChange;
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            gameManagerMaster.CallGameOverEvent();
        }
        SetUI();
    }

    void IncreaseHealth(int healthChange)
    {
        playerHealth += healthChange;
        if (playerHealth > maxPlayerHealth)
        {
            playerHealth = maxPlayerHealth;
        }
        SetUI();
    }

    void SetUI()
    {
        if (healthText != null)
        {
            healthText.text = playerHealth.ToString();
        }
    }

    void Update()
    {
        DeductHealth(1);
    }


}
