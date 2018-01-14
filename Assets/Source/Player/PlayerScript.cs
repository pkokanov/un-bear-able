using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float speed;
    public float jumpSpeed;
    public float lerpFactor;
    public float attackTime;
    public float attackCoolDown;
    public float height;
    public float width;
    public Vector3 initialJumpForce;
    public Vector3 gravity;
    public Animator animator;

    private Vector3 upperBoundary;
    private Vector3 lowerBoundary;
    private Vector3 leftBoundary;
    private Vector3 rightBoundary;

    private bool attackDisabled;

    private Dictionary<States, PlayerState> statesDict;
    private PlayerState currentState;
    
    public Dictionary<States, PlayerState> StatesDict {
        get { return statesDict; }
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

        attackDisabled = false;
        currentState = statesDict[States.Idle];

        upperBoundary = GameObject.Find("/Ground/UpperBoundary").transform.position;
        lowerBoundary = GameObject.Find("/Ground/LowerBoundary").transform.position;
        leftBoundary = GameObject.Find("/Ground/LeftBoundary").transform.position;
        rightBoundary = GameObject.Find("/Ground/RightBoundary").transform.position;
    }
    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        currentState.UpdateState();
        currentState.Update();
    }

    private void OnTriggerExit2D(Collider2D collision) {
        Debug.Log("asdf");
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


    public void ChangeState(PlayerState newState) {
        this.currentState.OnExit();
        this.currentState = newState;
        this.currentState.OnEnter();
    }

    public bool CanMoveHorizontally(float xDestination) {
        return xDestination - width > leftBoundary.x && xDestination + width < rightBoundary.x;
    }

    public bool CanMoveVertically(float yDestination) {
        return yDestination - height > lowerBoundary.y && yDestination - height < upperBoundary.y;
    }

}
