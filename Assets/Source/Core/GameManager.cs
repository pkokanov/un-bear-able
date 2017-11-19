using System.Collections;
using System.Collections.Generic;

public sealed class GameManager {

    public static GameManager instance = new GameManager();

    private bool gameStarted;

    private GameManager() {
        gameStarted = false;
    }

    public static GameManager Instance {
        get {
            return instance;
        }
    }


    public bool GameStarted {
        get {
            return gameStarted;
        }
        set {
            this.gameStarted = value;
        }
    }
}