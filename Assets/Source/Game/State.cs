using UnityEngine;

public class State<T> where T: MonoBehaviour {
    protected T owner;

    protected State(T owner) {
        this.owner = owner;
    }

    public virtual void UpdateState() {

    }

    virtual public void Update() {

    }

    public virtual void OnExit() {

    }

    public virtual void OnEnter() {

    }

    public virtual void OnCollisionEnter(Collision collision) {
        Debug.Log("EnteredCollision");
    }

    public virtual void OnCollisionExit(Collision collision) {
        Debug.Log("OnCollisionExit");
    }

    public virtual void OnTriggerEnter(Collider collider) {
        Debug.Log("OnTriggerEnter");
    }

    public virtual void OnTriggerExit(Collider collider) {
        Debug.Log("OnTriggerExit");
    }
}
