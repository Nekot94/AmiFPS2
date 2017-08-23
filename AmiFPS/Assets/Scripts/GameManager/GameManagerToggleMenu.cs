using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerToggleMenu : MonoBehaviour 
{
    private GameManagerMaster gameManagerMaster;
    public GameObject menu;


    private void OnEnable()
    {
        SetInitialReferences();
        gameManagerMaster.GameOverEvent += ToggleMenu;

    }

    private void OnDisable()
    {
        gameManagerMaster.GameOverEvent -= ToggleMenu;
    }

    private void Update()
    {
        CheckForMenuToggle();
    }

    private void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManagerMaster>();
    }

    void CheckForMenuToggle()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }


    void ToggleMenu()
    {
        if (menu != null)
        {
            menu.SetActive(!menu.activeSelf);
            gameManagerMaster.isMenuOn = !gameManagerMaster.isMenuOn;
            gameManagerMaster.CallMenuToggleEvent();
        }
    }

}
