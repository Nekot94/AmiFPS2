using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTogglePause : MonoBehaviour 
{
    private GameManagerMaster gameManagerMaster;
    public bool isPaused;

    private void OnEnable()
    {
        SetInitialReferences();
        gameManagerMaster.MenuToggleEvent += TogglePause;
        gameManagerMaster.InventoryUIEvent += TogglePause;
    }

    private void OnDisable()
    {
        gameManagerMaster.MenuToggleEvent -= TogglePause;
        gameManagerMaster.InventoryUIEvent -= TogglePause;
    }

    private void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManagerMaster>();
    }

    private void TogglePause()
    {
        //if (isPaused)
        //{
        //    Time.timeScale = 0;
        //    isPaused = false;
        //}
        //else
        //{
        //    Time.timeScale = 1;
        //    isPaused = true;
        //}
        Time.timeScale = isPaused ? 0 : 1;
        isPaused = !isPaused;
    }


}
