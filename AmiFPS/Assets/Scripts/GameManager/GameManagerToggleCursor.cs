using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerToggleCursor : MonoBehaviour 
{
    private GameManagerMaster gameManagerMaster;
    public bool isCursorLocked;


    private void OnEnable()
    {
        SetInitialReferences();
        gameManagerMaster.MenuToggleEvent += ToggleCursor;
        gameManagerMaster.InventoryUIEvent += ToggleCursor;
    }

    private void OnDisable()
    {
        gameManagerMaster.MenuToggleEvent -= ToggleCursor;
        gameManagerMaster.InventoryUIEvent -= ToggleCursor;
    }


    private void Start()
    {
        CheckIfCursorVisible();
    }

    private void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManagerMaster>();
    }

    void ToggleCursor()
    {
        isCursorLocked = !isCursorLocked;
        CheckIfCursorVisible();
    }

    void CheckIfCursorVisible()
    {
        Cursor.lockState = isCursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !Cursor.visible;
    }
}
