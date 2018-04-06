using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState {

    public PlayerMoveState(PlayerScript player) : base(player) {
    }

    public override void UpdateState() {
        if (!PlayerMovementInput() && 
            !Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.X)) {
            owner.StateMachine.ChangeState(owner.StatesDict[PlayerScript.States.Idle]);
        } else if (Input.GetKey(KeyCode.Space)) {
            owner.StateMachine.ChangeState(owner.StatesDict[PlayerScript.States.JumpPrep]);
        } else if (Input.GetKey(KeyCode.X) && !owner.AttackDisabled) {
            owner.StateMachine.ChangeState(owner.StatesDict[PlayerScript.States.Attack]);
        }
    }

    public override void Update() {
        float xMovement = 0;
        float yMovement = 0;
        if (Input.GetKey(KeyCode.LeftArrow)) {
            xMovement = 0 - owner.speed * Time.deltaTime;
            if (owner.transform.rotation.y == 0) {
                owner.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            xMovement = owner.speed * Time.deltaTime;
            if (owner.transform.rotation.y == 1) {
                owner.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        if (Input.GetKey(KeyCode.UpArrow)) {
            yMovement = owner.speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            yMovement = 0 - owner.speed * Time.deltaTime;
        }

        if (!owner.CanMoveHorizontally (owner.transform.position.x + xMovement)) {
            xMovement = 0;
        }

        if (!owner.CanMoveVertically(owner.transform.position.y + yMovement)) {
            yMovement = 0;
        }

        Vector3 destination = owner.transform.position + new Vector3(xMovement, yMovement, yMovement);
        owner.transform.position = Vector3.Lerp(owner.transform.position, destination, owner.lerpFactor);
    }

    public override void OnEnter() {
        Debug.Log("Entered PlayerMoveState");
        owner.animator.SetBool("isWalking", true);
    }

    public override void OnExit() {
        Debug.Log("Exited PlayerMoveState");
        owner.animator.SetBool("isWalking", false);
    }

}
