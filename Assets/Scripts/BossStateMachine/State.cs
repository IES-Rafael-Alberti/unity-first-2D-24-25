using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;


public class State : IState
{
    protected BossController Boss;
    private Vector2 PlayerDistance;

    public State(BossController Boss)
    {
        this.Boss = Boss;
    }

    public virtual void Entry()
    {
        // dejar que el estado lo cambie
    }

    public virtual void Exit()
    {
        // dejar que el estado lo cambie
    }

    public virtual void Update()
    {
        // calcular distancia al jugador
        // reducir vida
        Boss.currentHealth -= 10.0f * Time.deltaTime;
        // dejar que cada estado lo cambie

    }
}
