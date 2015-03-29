using UnityEngine;
using System.Collections;

public class Enemy : Character {

    public string displayName = "Enemy";
    public int maxHealth = 100;
    public float rangeOfSight = 5f;
    public Animation animation;
    public TextMesh overhead;

    private bool enemyTurn;
    private CharacterMove characterMove;
    private Transform target;
    public enum State { Idle, Chase };
    private State state;
    public delegate void FinishedMoving();
    FinishedMoving finishedMoving;

    private int initialHealth;

    void Start() {
        Health = maxHealth;
        initialHealth = Health;
        characterMove = GetComponent<CharacterMove>();
        finishedMoving = CheckForTarget;
        characterMove.finishedMoving = finishedMoving;
        state = State.Idle;
        UpdateOverHead();
    }

    void Update() {
        if (enemyTurn) {
			print (state);
            switch (state) {
                case State.Idle:
                    IdleState();
                    break;
                case State.Chase:
                    ChaseState();
                    break;
            }
            EndTurn();
        }
    }

    public override void decreaseHealth(int amount) {
        base.decreaseHealth(amount);
        if (Health <= 0) {
            Health = 0;
            UpdateOverHead();
            Kill();
        }
        UpdateOverHead();
    }

    public override void increaseHealth(int amount) {
        base.increaseHealth(amount);
        UpdateOverHead();
    }

    public void Kill() {
        print(displayName + " Killed.");
        Destroy(this.gameObject);
    }

    private void CheckForTarget() {
        Debug.DrawRay(transform.position, transform.forward * rangeOfSight, Color.red, 1);
        RaycastHit hit;
        Physics.Raycast(new Ray(), out hit, rangeOfSight);
    }

    private void IdleState() {
        characterMove.FaceRandom();
    }

    private void ChaseState() {

    }

    private void EndTurn() {
        EnemyTurn = false;
    }

    public void StartTurn() {
        EnemyTurn = true;
        if (!characterMove.IsMoving && !characterMove.IsTurning) {
            CheckForTarget();
        }
    }

    private void UpdateOverHead() {
        overhead.text = string.Format("{0}: {1}%", displayName, (int)Mathf.Ceil((float)Health / (float)maxHealth * 100f));
    }

    public bool EnemyTurn {
        get { return enemyTurn; }
        set { enemyTurn = value; }
    }
}
