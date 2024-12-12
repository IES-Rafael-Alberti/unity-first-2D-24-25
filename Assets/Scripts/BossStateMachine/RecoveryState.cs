using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryState : State
{
    public RecoveryState(BossController boss) : base(boss) {}

    public override void Entry()
    {
        base.Entry();
        Debug.Log("Recovery State Entered");
        Boss.StartCoroutine(RecoveryWait());
    }
    
    IEnumerator RecoveryWait()
    {
        yield return new WaitForSeconds(2f);
        if(Boss.GetHealthPercentage() < 0.5f)
            Boss.ChangeStateKey(States.Rage);
        else 
            Boss.ChangeStateKey(States.Follow);
    }
}
