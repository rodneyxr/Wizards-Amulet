using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private bool enemyTurn;

    void Start() {

    }

    void Update() {
        if (enemyTurn) {
            AIMove();
        }
    }

    void OnTriggerEnter(Collider other) {

    }

    public void AIMove() {
        print("Enemy moved.");
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
