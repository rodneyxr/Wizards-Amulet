using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    //private CharacterController cc;
    private PlayerLook playerLook;
    private PlayerMove playerMove;
    private SpellBook selectedSpell;
    private bool playerTurn;
	private bool learnFireBall;
	private bool learnIceBlitz;
    private Interaction interaction;
	
    void Start() {
        //cc = GetComponent<CharacterController>();
        playerLook = GetComponent<PlayerLook>();
        playerMove = GetComponent<PlayerMove>();
        interaction = GetComponentInChildren<Interaction>();
//        selectedSpell = SpellBook.FireBall;
    }

    void Update() {
        if (learnFireBall && Input.GetKeyDown(KeyCode.Alpha1)) {
            selectedSpell = SpellBook.FireBall;
		} else if (learnIceBlitz && Input.GetKeyDown(KeyCode.Alpha2)) {
            selectedSpell = SpellBook.IceBlitz;
        }

		if(learnFireBall || learnIceBlitz)
	        if (Input.GetButtonDown("Fire1") && !playerMove.IsMoving && !playerLook.IsTurning) {
	            SpellCaster.castSpell(selectedSpell, playerLook.PlayerCamera.transform.position, Quaternion.Euler(0f, playerLook.Yaw, 0f));
	            PlayerMoved();
	        }

        if (Input.GetKeyDown(KeyCode.F)) {
			print ("interact");
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

	public bool LearnFireBall {
		get { return learnFireBall; }
		set { learnFireBall = value; }
	}

	public bool LearnIceBlitz {
		get { return learnIceBlitz; }
		set { learnIceBlitz = value; }
	}

	public void learnSpell(string spellname){
		if (spellname.Equals ("fireball")) {
			LearnFireBall = true;
			selectedSpell = SpellBook.FireBall;
		}
		if (spellname.Equals ("iceblitz")) {
			LearnFireBall = true;
			selectedSpell = SpellBook.IceBlitz;
		}
	}





}
