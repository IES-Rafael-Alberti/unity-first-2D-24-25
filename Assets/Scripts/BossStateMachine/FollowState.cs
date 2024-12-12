using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : State
{
    public FollowState(BossController boss) : base(boss) { }

    public override void Entry()
    {
        base.Entry();
        Debug.Log("Follow State Entered");
        Boss.StartCoroutine(Spit());
    }

    public override void Update()
    {
        base.Update();
        if(Boss.GetHealthPercentage() < .5f) Boss.ChangeStateKey(States.Rage);
    }

    IEnumerator Spit()
    {
        yield return new WaitForSeconds(1f);
        Boss.ChangeStateKey(States.Spit);
    }
}
