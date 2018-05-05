using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearMinionScript : MonoBehaviour, Damageable {

    public Animator animator;
    public string playerTag;
    public GameObject player;

    public enum States: byte {
        Attack,
        Seek,
        Idle,
        MoveToAttack
    }

    private Dictionary<States, BearMinionState> statesDict;
    private StateMachine<BearMinionScript> stateMachine;

    public Dictionary<States, BearMinionState> StatesDict {
        get { return statesDict; }
    }

    public StateMachine<BearMinionScript> StateMachine {
        get { return stateMachine; }
    }

    void Awake() {
        statesDict = new Dictionary<States, BearMinionState>();
        stateMachine = new StateMachine<BearMinionScript>();

        statesDict[States.Attack] = new BearAttackState(this);
        statesDict[States.Seek] = new BearAttackState(this);
        statesDict[States.Idle] = new BearAttackState(this);
        statesDict[ States.MoveToAttack] = new BearAttackState(this);

        stateMachine.ChangeState(statesDict[States.Seek]);

        player = GameObject.FindWithTag(playerTag);
    }

    void Start () {
        
    }

    void Update() {
        stateMachine.Update();
    }

    public virtual void OnCollisionEnter(Collision collision) {
        stateMachine.OnCollisionEnter(collision);
    }

    public virtual void OnCollisionExit(Collision collision) {
        stateMachine.OnCollisionExit(collision);
    }

    public virtual void OnTriggerEnter(Collider collider) {
        stateMachine.OnTriggerEnter(collider);
    }

    public virtual void OnTriggerExit(Collider collider) {
        stateMachine.OnTriggerExit(collider);
    }

    public void OnHit(Vector3 hitDirection) {
        animator.SetTrigger("gotHit");
    }

}
