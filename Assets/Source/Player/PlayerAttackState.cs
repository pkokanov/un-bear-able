using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerAttackState : PlayerState {
    private float elapsedTime;

    public PlayerAttackState(PlayerScript player) : base(player) {
        elapsedTime = 0;
    }

    public override void UpdateState() {
        if(elapsedTime > player.attackTime) {  
            player.ChangeState(player.StatesDict[PlayerScript.States.Idle]);
        }
    }

    public override void Update() {
        elapsedTime += Time.deltaTime;
    }

    public override void OnExit() {
        Debug.Log("Exited PlayerAttackState");
        player.StartAttackCooldown();
    }

    public override void OnEnter() {
        elapsedTime = 0;  
        Debug.Log("Entering PlayerAttackState");
        player.animator.SetTrigger("hunterAttack");
    }
}
