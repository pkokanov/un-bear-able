using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerMoveState : PlayerState {
    public PlayerMoveState(PlayerScript player) : base(player) {
    }

    public override void UpdateState() {
        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) &&
            !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && 
            !Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.X)) {
            player.ChangeState(player.StatesDict[PlayerScript.States.Idle]);
        } else if (Input.GetKey(KeyCode.Space)) {
            player.ChangeState(player.StatesDict[PlayerScript.States.JumpPrep]);
        } else if (Input.GetKey(KeyCode.X) && !player.AttackDisabled) {
            player.ChangeState(player.StatesDict[PlayerScript.States.Attack]);
        }
    }

    public override void Update() {
        float xMovement = 0;
        float yMovement = 0;
        if (Input.GetKey(KeyCode.LeftArrow)) {
            xMovement = 0 - player.speed * Time.deltaTime;
            if (player.transform.rotation.y == 0) {
                player.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            xMovement = player.speed * Time.deltaTime;
            if (player.transform.rotation.y == 1) {
                player.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        if (Input.GetKey(KeyCode.UpArrow)) {
            yMovement = player.speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            yMovement = 0 - player.speed * Time.deltaTime;
        }

        if (!player.CanMoveHorizontally (player.transform.position.x + xMovement)) {
            xMovement = 0;
        }

        if (!player.CanMoveVertically(player.transform.position.y + yMovement)) {
            yMovement = 0;
        }

        Vector3 destination = player.transform.position + new Vector3(xMovement, yMovement);
        player.transform.position = Vector3.Lerp(player.transform.position, destination, player.lerpFactor);
    }

    public override void OnEnter() {
        Debug.Log("Entered PlayerMoveState");
        player.animator.SetBool("isWalking", true);
    }

    public override void OnExit() {
        Debug.Log("Exited PlayerMoveState");
        player.animator.SetBool("isWalking", false);
    }

}
