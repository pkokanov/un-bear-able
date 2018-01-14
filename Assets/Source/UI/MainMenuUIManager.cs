using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIManager : MonoBehaviour {

    public GameObject resumeButton;

    void Awake() {
    }

    private void Start() {
        if (GameManager.Instance.GameStarted && resumeButton) {
            resumeButton.SetActive(true);
        } else {
            resumeButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {
        
    }
}
