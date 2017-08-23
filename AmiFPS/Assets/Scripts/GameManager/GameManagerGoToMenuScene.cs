using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerGoToMenuScene : MonoBehaviour
{
	public GameManagerMaster gameManagerMaster;

	void OnEnable()
	{
		SetInitialReferences ();
		gameManagerMaster.GoToMainMenuEvent += GoToMenuScene;
	}

	void OnDisable()
	{
		gameManagerMaster.GoToMainMenuEvent -= GoToMenuScene;
	}

	void SetInitialReferences()
	{
		gameManagerMaster = GetComponent<GameManagerMaster> ();
	}

	void GoToMenuScene()
	{
		SceneManager.LoadScene (0);
	}
}
