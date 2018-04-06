using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearMinionScript : MonoBehaviour, Damageable {

    public Animator animator;
    private StateMachine<BearMinionScript> stateMachine;

    void Awake() {

    }

    void Start () {
        
    }

    void Update () {
        
    }

    public void OnHit(Vector3 hitDirection) {
        animator.SetTrigger("gotHit");
    }

}
