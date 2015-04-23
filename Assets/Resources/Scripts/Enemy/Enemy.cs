using UnityEngine;
using System.Collections;

public class Enemy : Character {

    public string displayName = "Enemy";
    public int maxHealth = 100;
    public float rangeOfSight = 5f;
    public Animation animation;
    public TextMesh overhead;
    private Player player;
    private PlayerStats playerStats;
    private bool enemyTurn;
    private CharacterMove characterMove;
    private Transform target;
    public enum State { Idle, Chase, Attack };
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
            switch (state) {
                case State.Idle:
                    IdleState();
                    break;
                case State.Chase:
                    ChaseState();
                    break;
                case State.Attack:
                    AttackState();
                    break;
            }
            EndTurn();
        }
    }

    public override void decreaseHealth(int amount) {
        print("decrease health");
        base.decreaseHealth(amount);
        AttackState();
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
        if (player == null) {
            player = GameObject.Find("Player(Clone)").GetComponent<Player>();
            playerStats = player.GetComponent<PlayerStats>();
        }
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < 10f) {
            transform.LookAt(player.transform.position);
            state = State.Attack;
        } else {
            state = State.Idle;
        }
    }

    private void IdleState() {
        characterMove.FaceRandom();
    }

    private void AttackState() {
        if (player == null) {
            player = GameObject.Find("Player(Clone)").GetComponent<Player>();
            playerStats = player.GetComponent<PlayerStats>();
        }
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance > 7f) {
            ChaseState();
            state = State.Chase;
            return;
        }
        print("attack");
        //animation.Play("attack1");
        StartCoroutine(PlayAnimOnce("attack1"));
        playerStats.decreaseHealth(5);
    }
    private void ChaseState() {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < 7f) {
            state = State.Attack;
        } else if (distance > 7f && distance < 16f) {
            characterMove.Move(Direction.Forward);
        } else if (Vector3.Distance(player.transform.position, transform.position) > 16f) {
            state = State.Idle;
        }
    }

    private void EndTurn() {
        EnemyTurn = false;
    }

    public void StartTurn() {
        EnemyTurn = true;
        if (!characterMove.IsMoving && !characterMove.IsTurning && state != State.Chase && state != State.Attack) {
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

    bool animating = false;
    IEnumerator PlayAnimOnce(string name) {
        if (!animating) {
            animating = true;
            float duration = animation.GetClip(name).length;
            animation.playAutomatically = false;
            animation.Play(name);
            yield return new WaitForSeconds(duration);
            animating = false;
            animation.Play("idle");
            animation.playAutomatically = true;
        }
        yield return null;
    }
}
