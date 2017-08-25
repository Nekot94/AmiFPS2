using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerGameOver : MonoBehaviour 
{
    public GameObject gameOverPanel;

    private GameManagerMaster gameManagerMaster;

    private void OnEnable()
    {
        SetInitialReferences();
        gameManagerMaster.GameOverEvent += GameOver;
    }

    private void OnDisable()
    {
        gameManagerMaster.GameOverEvent -= GameOver;
    }

    private void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManagerMaster>();
    }

    private void GameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            gameManagerMaster.CallGameOverEvent();
    }
}
