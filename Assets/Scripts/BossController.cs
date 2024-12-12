using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private GameObject SpikesPrefab;
    [SerializeField] private GameObject SpitPrefab;
    [SerializeField] private GameObject RageCloud;

    [SerializeField] private PlayerController Player;
    [SerializeField] private float maxHealth = 200;
    
    
    public float currentHealth;
    
    State currentState;
    Dictionary<States, State> statesDict = new Dictionary<States, State>();

    // ready
    void Start() 
    {
        // inicializar datos boss
        currentHealth = maxHealth;
        
        // inicializar estados:
        //      definir estado inicial
        currentState = new FollowState(this);
        currentState.Entry();
        //      crear lista de estados
        statesDict.Add(States.Follow, currentState);
        statesDict.Add(States.Rage, new RageState(this));
        statesDict.Add(States.Spit, new SpitState(this));
        statesDict.Add(States.Burp, new BurpState(this));
        statesDict.Add(States.Recovery, new RecoveryState(this));
        
        //      preparar sistema de eventos
    }

    // process
    void Update()
    {
        // llamar update del estado actual
        currentState.Update();
    }

    public float GetHealthPercentage()
    {
        return currentHealth / maxHealth;
    }

    public void ChangeStateKey(States newState)
    {
        if(statesDict.ContainsKey(newState))
        {
            ChangeState(statesDict[newState]);
        }
        else
        {
            Debug.LogWarning("State not in list.");
        }
    }
    
    void ChangeState(State newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Entry();
    }

    public void ShootSpit()
    {
        GameObject instSpit = Instantiate(SpitPrefab, transform.position + new Vector3(1,1,0), Quaternion.identity);
        instSpit.GetComponent<Rigidbody2D>().AddForce((Vector2.up+Vector2.left) * 3f, ForceMode2D.Impulse);
    }

    public void Burp() {
        GameObject instSpikes = Instantiate(SpikesPrefab, new Vector3(Player.transform.position.x, -1.77f, 0), Quaternion.identity);
    }

    public void RageUp() {
        RageCloud.SetActive(true);
    }
    public void RageDown() {
        RageCloud.SetActive(false);
    }
}

public enum States
{
    Follow, Spit, Burp, Recovery, Rage,
}