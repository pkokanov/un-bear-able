using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerIdleState : PlayerState {

    public PlayerIdleState(PlayerScript player): base(player) {
    }

    override public void UpdateState() {
        if (Input.GetKey(KeyCode.Space)) {
            owner.StateMachine.ChangeState(owner.StatesDict[PlayerScript.States.JumpPrep]);
        } else if (Input.GetKey(KeyCode.X) && !owner.AttackDisabled) {
            owner.StateMachine.ChangeState(owner.StatesDict[PlayerScript.States.Attack]);
        } else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) ||
                   Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) {
            owner.StateMachine.ChangeState(owner.StatesDict[PlayerScript.States.Move]);
        }
    }

    public override void OnEnter() {
        Debug.Log("Entered PlayerIdleState");
    }

    public override void OnExit() {
        Debug.Log("Exited PlayerIdleState");
    }
}