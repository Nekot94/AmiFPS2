using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerMaster : MonoBehaviour 
{
    public delegate void GameManagerEventHandler();
    public event GameManagerEventHandler MenuToggleEvent;
    public event GameManagerEventHandler InventoryUIEvent;
    public event GameManagerEventHandler RestartLevelEvent;
    public event GameManagerEventHandler GoToMainMenuEvent;
    public event GameManagerEventHandler GameOverEvent;

    public bool isGameOver;
    public bool isMenuOn;
    public bool isInventoryOn;

    public void CallMenuToggleEvent()
    { 
        if(MenuToggleEvent != null)
        {
            MenuToggleEvent();
        }
    }

    public void CallInventoryUIEvent()
    {
        if (InventoryUIEvent != null)
        {
            InventoryUIEvent();
        }
    }

    public void CallRestartLevelEvent()
    {
        if (RestartLevelEvent != null)
        {
            RestartLevelEvent();
        }
    }

    public void CallGoToMainMenuEvent()
    {
        if (GoToMainMenuEvent != null)
        {
            GoToMainMenuEvent();
        }
    }

    public void CallGameOverEvent()
    {
        if (GameOverEvent != null)
        {
            isGameOver = true;
            GameOverEvent();
        }
    }








}
