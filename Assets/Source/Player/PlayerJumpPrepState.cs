using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerJumpPrepState : PlayerState {
    public PlayerJumpPrepState(PlayerScript player) : base(player) {
    }

    public override void UpdateState() {
        if (owner.animator.GetBool("isJumping")) {
            owner.StateMachine.ChangeState(owner.StatesDict[PlayerScript.States.Jumping]);
        }
    }

    public override void Update() {

    }

    public override void OnEnter() {
        Debug.Log("Entered PlayerJumpPrepState");
        owner.animator.SetTrigger("hunterStartJump");
    }

    public override void OnExit() {
        Debug.Log("Exited PlayerJumpPrepState");
    }
}