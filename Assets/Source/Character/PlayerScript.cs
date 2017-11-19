using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float speed;
    public float lerpFactor;
    public float jumpSpeed;
    public float jumpHeight;
    public float attackSpeed;

    private bool isGrounded;
    // Use this for initialization
    void Start() {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update() {
        Vector3 destination = transform.position;
        float deltaTime = Time.deltaTime;

        if(Input.GetKey(KeyCode.LeftArrow)) {
            destination = transform.position - new Vector3(speed * deltaTime, 0, 0);
        }

        if(Input.GetKey(KeyCode.RightArrow)) {
            destination = transform.position + new Vector3(speed * deltaTime, 0, 0);
        }

        transform.position = Vector3.Lerp(transform.position, destination, lerpFactor);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {
        }
    }


}
