using UnityEngine;
using System.Collections;

public class CharacterLook : MonoBehaviour {

    // Components
    private CharacterController cc; // the character controller

    // Constants
    private const float lerpSpeed = 7f;

    // Yaw
    private float destYaw = 0f; // destination yaw (for smooth turning)
    private float[] direction = new float[] { 0f, 90f, 180f, 270f };
    private int facing = 0;
    private bool isTurning = false;

    void Start() {
        cc = GetComponent<CharacterController>(); // get the character controller on the player
    }

    //void Update() {
    //    // rotation
    //    if (Input.GetKeyDown(KeyCode.Q)) {
    //        Turn(-1);
    //    } else if (Input.GetKeyDown(KeyCode.E)) {
    //        Turn(1);
    //    }
    //}

    public void TurnLeft() {
        Turn(-1);
    }

    public void TurnRight() {
        Turn(1);
    }

    private void Turn(int turn) {
        isTurning = true;
        facing += turn;
        if (facing == -1)
            facing = 3;
        else if (facing == 4)
            facing = 0;
        destYaw = direction[facing];
    }

    void LateUpdate() {
        if (isTurning) {
            if (Mathf.Abs(destYaw - transform.rotation.eulerAngles.y) < 0.1f) {
                cc.transform.rotation = Quaternion.Euler(0f, destYaw, 0f);
                isTurning = false;
            } else
                cc.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, destYaw, 0f), lerpSpeed * Time.deltaTime);
        }
    }

    public float Yaw {
        get { return destYaw; }
    }

    public bool IsTurning {
        get { return isTurning; }
    }

}
