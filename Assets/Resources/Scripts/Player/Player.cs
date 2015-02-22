using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    //private CharacterController cc;
    private PlayerLook playerLook;
    private PlayerMove playerMove;
    private SpellBook selectedSpell;
    private bool playerTurn;
    private Interaction interaction;

    void Start() {
        //cc = GetComponent<CharacterController>();
        playerLook = GetComponent<PlayerLook>();
        playerMove = GetComponent<PlayerMove>();
        interaction = GetComponentInChildren<Interaction>();
        selectedSpell = SpellBook.FireBall;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            selectedSpell = SpellBook.FireBall;
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            selectedSpell = SpellBook.IceBlitz;
        }

        if (Input.GetButtonDown("Fire1") && !playerMove.IsMoving && !playerLook.IsTurning) {
            SpellCaster.castSpell(selectedSpell, playerLook.PlayerCamera.transform.position, Quaternion.Euler(0f, playerLook.Yaw, 0f));
            PlayerMoved();
        }

        if (Input.GetKeyDown(KeyCode.F)) {
            interaction.Interact();
        }
    }

    public void PlayerMoved() {
        //print("Player moved.");
        PlayerTurn = false;
    }

    public void YourTurn() {
        PlayerTurn = true;
    }

    public bool PlayerTurn {
        get { return playerTurn; }
        set { playerTurn = value; }
    }


}
