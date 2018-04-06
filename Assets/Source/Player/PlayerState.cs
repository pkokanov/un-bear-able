using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerState: State<PlayerScript> {

    public PlayerState(PlayerScript player):base(player) {
        this.owner = player;
    }

    public static bool PlayerMovementInput() {
        return (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) ||
                Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow));
    }
}