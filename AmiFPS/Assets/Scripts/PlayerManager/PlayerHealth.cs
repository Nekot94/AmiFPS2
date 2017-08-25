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
        
    }

    private void OnDisable()
    {
        
    }

    void SetInitialReferences()
    {
        gameManagerMaster = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerMaster>();

    }




}
