using UnityEngine;

public class StateMachine<T> where T : MonoBehaviour {

    private State<T> currentState;


    public void ChangeState(State<T> newState) {
        if (currentState != null)
            this.currentState.OnExit();
        this.currentState = newState;
        this.currentState.OnEnter();
    }

    public void Update() {
        if(currentState != null)
            currentState.UpdateState();
            currentState.Update();
    }

    public virtual void OnCollisionEnter(Collision collision) {
        if(currentState != null)
            currentState.OnCollisionEnter(collision);
    }

    public virtual void OnCollisionExit(Collision collision) {
        if (currentState != null)
            currentState.OnCollisionExit(collision);
    }

    public virtual void OnTriggerEnter(Collider collider) {
        if (currentState != null)
            currentState.OnTriggerEnter(collider);
    }

    public virtual void OnTriggerExit(Collider collider) {
        if (currentState != null)
            currentState.OnTriggerExit(collider);
    }
}
