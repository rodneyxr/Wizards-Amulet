using UnityEngine;
using System.Collections;

public class Enemy : Character {

    private bool enemyTurn;
    private CharacterMove characterMove;

    void Start() {
        characterMove = GetComponent<CharacterMove>();
    }

    void Update() {
        if (enemyTurn) {
            AIMove();
        }
    }

    void OnTriggerEnter(Collider other) {

    }

    public void AIMove() {
        //print("Enemy moved.");
        //characterMove.Move();
        EnemyTurn = false;
    }

    public void YourTurn() {
        EnemyTurn = true;
    }

    public bool EnemyTurn {
        get { return enemyTurn; }
        set { enemyTurn = value; }
    }
}
