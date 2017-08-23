using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerToggleInventory : MonoBehaviour
{

	public GameObject inventoryUI;
	public string toggleInventoryButton;
	private GameManagerMaster gameManagerMaster;

	void Start()
	{
		SetInitialReferences ();
	}

	void Update()
	{
		CheckInventoryUIToggleRequest ();
	}

	void SetInitialReferences()
	{
		gameManagerMaster = GetComponent<GameManagerMaster> ();
	}

	void CheckInventoryUIToggleRequest()
	{
		if (Input.GetButtonDown(toggleInventoryButton) && !gameManagerMaster.isGameOver
			&& !gameManagerMaster.isMenuOn)
		{
			ToggleInventoryUIOn ();
		}
	}

	void ToggleInventoryUIOn()
	{
		inventoryUI.SetActive(!inventoryUI.activeSelf);
		gameManagerMaster.isInventoryOn = !gameManagerMaster.isInventoryOn;
		gameManagerMaster.CallInventoryUIEvent ();
	}

}
