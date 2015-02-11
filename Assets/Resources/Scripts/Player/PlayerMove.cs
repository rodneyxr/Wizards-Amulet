using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float moveSpeed = 10f; // how fast the player moves

    private CharacterController cc; // character controller attached to the player
    private PlayerLook playerLook; // to see where the player is looking

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

    public void Start() {
        cc = GetComponent<CharacterController>(); // grab the character controller
        playerLook = GetComponentInChildren<PlayerLook>();
    }

    public void Update() {
        if (!isMoving) {
            // get the player input
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            // prevent moving diagonally
            if (Mathf.Abs(input.x) > Mathf.Abs(input.y)) {
                input.y = 0;
            } else {
                input.x = 0;
            }

            // initiate the move
            if (input != Vector2.zero && !isMoving) {
                StartCoroutine(move(cc.transform));
            }
        }
    }

    public IEnumerator move(Transform transform) {
        // don't allow any more movement until finished with current move
        isMoving = true;

        // save the current position
        startPosition = cc.transform.position;

        // calcultate destination position to move to
        if (gridOrientation == Orientation.Horizontal) {
            endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * GameManager.TileSize, startPosition.y, startPosition.z + System.Math.Sign(input.y) * GameManager.TileSize); // calculate the destination tile
            endPosition = Quaternion.Euler(0, playerLook.Yaw, 0) * (endPosition - startPosition) + startPosition; // rotate the move relative to which way the character is facing
        } else {
            endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * GameManager.TileSize, startPosition.y + System.Math.Sign(input.y) * GameManager.TileSize, startPosition.z);
        }

        // check if the destination is valid
        bool canMove = true;
        RaycastHit hit;
        Vector3 moveDirection = (endPosition - startPosition).normalized;
        Debug.DrawRay(startPosition, moveDirection, Color.red, 1);
        if (Physics.Raycast(startPosition, moveDirection, out hit, GameManager.TileSize + (GameManager.TileSize / 2 - .01f))) {
            //if (hit.collider.tag == "Enemy" || hit.collider.tag == "NonWalkable") {
            canMove = false;
            //}

        }

        // smoothly move to new position
        if (canMove) {
            float t = 0f; // lerp speed
            while (t < 1f) {
                t += Time.deltaTime * (moveSpeed / GameManager.TileSize); // calculate the time for lerp
                cc.transform.position = Vector3.Lerp(startPosition, endPosition, t); // smooth player move
                yield return null;
            }
        }

        // finished moving
        isMoving = false;
        yield return 0;
    }

    public bool IsMoving {
        get { return isMoving; }
    }
}
