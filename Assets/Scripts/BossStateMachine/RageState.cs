using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageState : State
{
    public RageState(BossController Boss) : base(Boss) {}

    public override void Entry()
    {
        base.Entry();
        Debug.Log("Rage State Entered");
        Boss.RageUp();
        Boss.StartCoroutine(Burp());
    }

    public override void Exit() {
        base.Exit();
        Boss.RageDown();
    }

    IEnumerator Burp()
    {
        yield return new WaitForSeconds(5f);
        Boss.ChangeStateKey(States.Burp);
    }
}
