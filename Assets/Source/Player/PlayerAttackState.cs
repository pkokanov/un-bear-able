using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerAttackState : PlayerState {
    private float elapsedTime;
    private bool checkedHit;

    public PlayerAttackState(PlayerScript player) : base(player) {
        elapsedTime = 0;
        checkedHit = false;
    }

    public override void UpdateState() {
        if(elapsedTime > owner.attackTime) {  
            owner.StateMachine.ChangeState(owner.StatesDict[PlayerScript.States.Idle]);
        }
    }

    public override void Update() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= owner.attackTime / 2 && !checkedHit) {
            RaycastHit hit;
            bool bearHit = Physics.Linecast(owner.transform.position, owner.swordTransform.position, out hit, owner.attackingLayer);
            if (bearHit) {
                Damageable damageable = hit.transform.GetComponent<Damageable>();
                if (damageable != null) {
                    damageable.OnHit(owner.transform.right);
                }
            }
            checkedHit = true;
        }
    }

    public override void OnExit() {
        Debug.Log("Exited PlayerAttackState");
        owner.StartAttackCooldown();
    }

    public override void OnEnter() {
        Debug.Log("Entering PlayerAttackState");
        elapsedTime = 0;
        checkedHit = false;
        owner.animator.SetTrigger("hunterAttack");
    }
}
