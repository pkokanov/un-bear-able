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
        if (player.transform.position.y <= startingY) {
            player.transform.position = new Vector3(player.transform.position.x, startingY);
            player.ChangeState(player.StatesDict[PlayerScript.States.Idle]);
        }
    }

    public override void Update() {
        Vector3 destination = player.transform.position + jumpForce + new Vector3(xMomentum * player.jumpSpeed * Time.deltaTime, 0);
        player.transform.position = Vector3.Lerp(player.transform.position, destination, player.lerpFactor);
        jumpForce -= player.gravity;
    }

    public override void OnEnter() {
        Debug.Log("Entered PlayerJumpState");
        startingY = player.transform.position.y;
        jumpForce = player.initialJumpForce;
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
        player.animator.SetBool("isJumping", false);
    }
}
