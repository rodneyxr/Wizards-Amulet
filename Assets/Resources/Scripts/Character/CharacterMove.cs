using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {

    // Constants
    private const float lerpSpeed = 7f;
    public float moveSpeed = 10f; // how fast the player moves

    private CharacterController cc; // character controller attached to the player
    private CharacterLook characterLook; // to see where the player is looking
    private Character player; // the main player class

    private enum Orientation {
        Horizontal, // navigate the ground
        Vertical // climbing ladders
    };
    private Orientation gridOrientation = Orientation.Horizontal;

    // Movement
    private Vector2 input; // current input
    private bool isMoving = false; // true if the player is currently moving
    private Vector3 startPosition; // position at start of a move
    private Vector3 endPosition; // destination position

    // Turning
    private bool isTurning = false;
    private float destYaw = 0f;
    private int facing = 0;
    private float[] direction = new float[] { 0f, 90f, 180f, 270f };

    public Enemy.FinishedMoving finishedMoving;
    private Action lastAction;

    public void Start() {
        cc = GetComponent<CharacterController>(); // grab the character controller
        characterLook = GetComponentInChildren<CharacterLook>();
        player = GetComponentInChildren<Character>();
    }

    //public void Update() {
    //    if (!isMoving) {
    //        // get the player input
    //        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    //        // prevent moving diagonally
    //        if (Mathf.Abs(input.x) > Mathf.Abs(input.y)) {
    //            input.y = 0;
    //        } else {
    //            input.x = 0;
    //        }

    //        // initiate the move
    //        if (input != Vector2.zero && !isMoving) {
    //            StartCoroutine(move(cc.transform));
    //        }
    //    }
    //}

    public void Move(Direction direction) {
		switch ((int)cc.transform.rotation.eulerAngles.y) {
		case 0:
			break;
		case 90:
			direction = Direction.Right;
			break;
		case 180:
			direction = Direction.Back;
			break;
		case 270:
			direction = Direction.Left;
			break;
		default:
			break;
		}
        input = new Vector2();
        switch (direction) {
            case Direction.Forward:
                input.y = 1;
                break;
            case Direction.Back:
                input.y = -1;
                break;
            case Direction.Left:
                input.x = -1;
                break;
            case Direction.Right:
                input.x = 1;
                break;
        }
        Move();
    }

    private void Move() {
        if (!isMoving) {
			StartCoroutine(move(cc.transform));
        }
        lastAction = Action.Move;
    }


    private IEnumerator move(Transform transform) {
        // don't allow any more movement until finished with current move
        isMoving = true;

        // save the current position
        startPosition = cc.transform.position;

        // calcultate destination position to move to
        if (gridOrientation == Orientation.Horizontal) {
            endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * GameManager.TileSize, startPosition.y, startPosition.z + System.Math.Sign(input.y) * GameManager.TileSize); // calculate the destination tile
            endPosition = Quaternion.Euler(0, characterLook.Yaw, 0) * (endPosition - startPosition) + startPosition; // rotate the move relative to which way the character is facing
        } else {
            endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * GameManager.TileSize, startPosition.y + System.Math.Sign(input.y) * GameManager.TileSize, startPosition.z);
        }

        // check if the destination is valid
        bool canMove = true;
        RaycastHit hit;
        Vector3 moveDirection = (endPosition - startPosition).normalized;
        Debug.DrawRay(startPosition, moveDirection, Color.red, 1);
        if (Physics.Raycast(startPosition, moveDirection, out hit, GameManager.TileSize + (GameManager.TileSize / 2 - .01f))) {
         //   if (hit.collider.name != "outerbox" ) {
				print (hit.collider.name);
				canMove = false;
           // }

        }

        // smoothly move to new position
        if (canMove) {
            float t = 0f; // lerp speed
            while (t < 1f) {
                t += Time.deltaTime * (moveSpeed / GameManager.TileSize); // calculate the time for lerp
                cc.transform.position = Vector3.Lerp(startPosition, endPosition, t); // smooth player move
                yield return null;
            }
            //player.PlayerMoved();
        }

        // finished moving
        isMoving = false;
        if (lastAction.Equals(Action.Move)) finishedMoving();
        yield return 0;
    }

    public void Face(int turn) {
        //isTurning = true;
        facing += turn;
        if (facing == -1)
            facing = 3;
        else if (facing == 4)
            facing = 0;
        destYaw = direction[facing];
        //StartCoroutine(FaceRoutine());
        Face();
    }

    public void FaceRandom() {
        //isTurning = true;
        facing = Random.Range(0, 4);
        destYaw = direction[facing];
        Face();
        //StartCoroutine(FaceRoutine());
    }

    private void Face() {
        isTurning = true;
        StartCoroutine(FaceRoutine());
        lastAction = Action.Face;
    }

    IEnumerator FaceRoutine() {
        while (isTurning) {
            if (Mathf.Abs(destYaw - transform.rotation.eulerAngles.y) < 0.1f) {
                cc.transform.rotation = Quaternion.Euler(0f, destYaw, 0f);
                isTurning = false;
                if (lastAction.Equals(Action.Face)) finishedMoving();
            } else
                cc.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, destYaw, 0f), lerpSpeed * Time.deltaTime);
            yield return 0;
        }
        yield return null;
    }

    public bool IsMoving {
        get { return isMoving; }
    }

    public bool IsTurning {
        get { return isTurning; }
    }

    private enum Action {
        Move, Face
    }
}
