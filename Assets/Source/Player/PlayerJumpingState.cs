using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerJumpingState : PlayerState {
    private float startingY;
    private float xMomentum;
    private Vector3 jumpForce;

    public PlayerJumpingState(PlayerScript player) : base(player) {
        startingY = player.transform.position.y;
        jumpForce = player.initialJumpForce;
        xMomentum = 0;
    }

    public override void UpdateState() {
        if (owner.transform.position.y <= startingY) {
            owner.transform.position = new Vector3(owner.transform.position.x, startingY, owner.transform.position.z);
            owner.StateMachine.ChangeState(owner.StatesDict[PlayerScript.States.Idle]);
        }
    }

    public override void Update() {
        Vector3 initialShadowPos = owner.shadowTransform.position;
        Vector3 destination = owner.transform.position + jumpForce + new Vector3(xMomentum * owner.jumpSpeed * Time.deltaTime, 0);
        if(!owner.CanMoveHorizontally(destination.x)) {
            destination.x = owner.transform.position.x;
        }
        owner.transform.position = Vector3.Lerp(owner.transform.position, destination, owner.lerpFactor);
        jumpForce -= owner.gravity;
        owner.shadowTransform.position = new Vector3(owner.shadowTransform.position.x, initialShadowPos.y, owner.shadowTransform.position.z);
    }

    public override void OnEnter() {
        Debug.Log("Entered PlayerJumpState");
        startingY = owner.transform.position.y;
        jumpForce = owner.initialJumpForce;
        xMomentum = 0;
        if(Input.GetKey(KeyCode.LeftArrow)) {
            xMomentum--;
        }
        if(Input.GetKey(KeyCode.RightArrow)) {
            xMomentum++;
        }
    }

    public override void OnExit() {
        Debug.Log("Exited PlayerJumpState");
        owner.animator.SetBool("isJumping", false);
    }
}
