using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerState: State {

    protected PlayerScript player;

    public PlayerState(PlayerScript player) {
        this.player = player;
    }

    public virtual void UpdateState() {

    }

    virtual public void Update() {

    }

    public virtual void OnExit() {

    }

    public virtual void OnEnter() {

    }

    public virtual void OnCollisionEnter(Collision2D collision) {

    }

    public virtual void OnCollisionExit(Collision2D collision) {

    }

    public virtual void OnTriggerEnter(Collider2D collider) {

    }

    public virtual void OnTriggerExit(Collider2D collider) {

    }

    public static bool PlayerMovementInput() {
        return (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) ||
                Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow));
    }
}