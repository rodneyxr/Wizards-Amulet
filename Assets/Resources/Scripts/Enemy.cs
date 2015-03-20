using UnityEngine;
using System.Collections;

public class Enemy : Character {

    private bool enemyTurn;
    private CharacterMove characterMove;
    private Transform target;
    public enum State { Idle, Chase };
    private State state;

    void Start() {
        characterMove = GetComponent<CharacterMove>();
        state = State.Idle;
    }

    void Update() {
        if (enemyTurn) {
            switch (state) {
                case State.Idle:
                    IdleState();
                    break;
                case State.Chase:
                    ChaseState();
                    break;

                default:
                    break;
            }
            EndTurn();
        }
    }

    void OnTriggerEnter(Collider other) {

    }

    private void IdleState() {
        characterMove.Face(-1);
        print("face left");
    }

    private void ChaseState() {

    }

    private void EndTurn() {
        EnemyTurn = false;
    }

    public void StartTurn() {
        EnemyTurn = true;
    }

    public bool EnemyTurn {
        get { return enemyTurn; }
        set { enemyTurn = value; }
    }
}
