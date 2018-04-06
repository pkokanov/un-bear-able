using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour, Damageable {

    public float speed;
    public float jumpSpeed;
    public float lerpFactor;
    public float attackTime;
    public float attackCoolDown;
    public float height;
    public float width;
    public LayerMask attackingLayer;
    public Transform swordTransform;
    public Transform shadowTransform;
    public Vector3 initialJumpForce;
    public Vector3 gravity;
    public Animator animator;

    private Vector3 upperBoundary;
    private Vector3 lowerBoundary;
    private Vector3 leftBoundary;
    private Vector3 rightBoundary;

    private float attackRange;
    private bool attackDisabled;

    private Dictionary<States, PlayerState> statesDict;
    private StateMachine<PlayerScript> stateMachine;

    public Dictionary<States, PlayerState> StatesDict {
        get { return statesDict; }
    }

    public StateMachine<PlayerScript> StateMachine {
        get { return stateMachine; }
    }

    public float AttackRange {
        get { return attackRange;  }
    }

    public bool AttackDisabled {
        get { return attackDisabled; }
    }

    public enum States :byte {
        Idle,
        Move,
        Attack,
        JumpPrep,
        Jumping
    }

    void Awake() {
        statesDict = new Dictionary<States, PlayerState>();
        statesDict[States.Idle] = new PlayerIdleState(this);
        statesDict[States.Move] = new PlayerMoveState(this);
        statesDict[States.Attack] = new PlayerAttackState(this);
        statesDict[States.JumpPrep] = new PlayerJumpPrepState (this);
        statesDict[States.Jumping] = new PlayerJumpingState(this);
        stateMachine = new StateMachine<PlayerScript>();
        stateMachine.ChangeState(statesDict[States.Idle]);

        attackDisabled = false;

        upperBoundary = GameObject.Find("/Ground/UpperBoundary").transform.position;
        lowerBoundary = GameObject.Find("/Ground/LowerBoundary").transform.position;
        leftBoundary = GameObject.Find("/Ground/LeftBoundary").transform.position;
        rightBoundary = GameObject.Find("/Ground/RightBoundary").transform.position;

        attackRange = swordTransform.position.x - transform.position.x;
    }

    // Use this for initialization
    void Start() {
        transform.position += new Vector3(0, 0, transform.position.y - transform.position.z - height/2);
    }

    // Update is called once per frame
    void Update() {
        stateMachine.Update();
    }

    public virtual void OnCollisionEnter(Collision collision) {
        stateMachine.OnCollisionEnter(collision);
    }

    public virtual void OnCollisionExit(Collision collision) {
        stateMachine.OnCollisionExit(collision);
    }

    public virtual void OnTriggerEnter(Collider collider) {
        stateMachine.OnTriggerEnter(collider);
    }

    public virtual void OnTriggerExit(Collider collider) {
        stateMachine.OnTriggerExit(collider);
    }

    IEnumerator AttackCooldownTimer() {
        float elapsedTime = 0;
        while(elapsedTime < attackCoolDown) {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        attackDisabled = false;
    }

    public void StartAttackCooldown() {
        attackDisabled = true;
        StartCoroutine("AttackCooldownTimer");
    }

    public bool CanMoveHorizontally(float xDestination) {
        return xDestination - width > leftBoundary.x && xDestination + width < rightBoundary.x;
    }

    public bool CanMoveVertically(float yDestination) {
        return yDestination - height > lowerBoundary.y && yDestination - height < upperBoundary.y;
    }

    public void OnHit(Vector3 hitDirection) {

    }
}
