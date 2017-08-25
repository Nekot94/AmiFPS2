using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerMaster : MonoBehaviour 
{
    public delegate void PlayerHealthEventHandler(int healthChanged);
    public event PlayerHealthEventHandler EventPlayerHealthDeduction;
    public event PlayerHealthEventHandler EventPlayerHealthIncrease;

    //public void CallPlayerHealthDeduction(int healthChange)
    //{
    //    if (EventPlayerHealthDeduction != null)
    //        EventPlayerHealthDeduction(healthChange);
    //}

    //public void CallPlayerHealthIncrease(int healthChange)
    //{
    //    if (EventPlayerHealthIncrease != null)
    //        EventPlayerHealthIncrease(healthChange);
    //}

    
    public void CallEvent(PlayerHealthEventHandler PlayerHealthHandler, int healthChange)
    {
        if (PlayerHealthHandler != null)
            PlayerHealthHandler(healthChange);
    }
    
}
