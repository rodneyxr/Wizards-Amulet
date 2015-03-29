﻿using UnityEngine;
using UnityEngine.UI;

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
	private int manaCost;
	//player reference
	private PlayerStats playerStats;

	//UI vars
	public RawImage UI_img_fireball;
	public RawImage UI_img_fireball_selected;
	public RawImage UI_img_fireball_deactivated;
	public RawImage UI_img_frostbolt;
	public RawImage UI_img_frostbolt_selected;
	public RawImage UI_img_frostbolt_deactivated;
	public Text txt_notification_top;




	
    void Start() {
        //cc = GetComponent<CharacterController>();
		playerStats = GameObject.Find ("Player").GetComponent<PlayerStats> ();
        playerLook = GetComponent<PlayerLook>();
        playerMove = GetComponent<PlayerMove>();
        interaction = GetComponentInChildren<Interaction>();
//        selectedSpell = SpellBook.FireBall;
		UI_img_frostbolt.enabled = false;
		UI_img_frostbolt_selected.enabled = false;
		UI_img_fireball.enabled = false;
		UI_img_fireball_selected.enabled = false;
    }

    void Update() {
        if (learnFireBall && Input.GetKeyDown(KeyCode.Alpha1)) {
			selectSpell("fireball");
		}
		if (learnIceBlitz && Input.GetKeyDown(KeyCode.Alpha2)) {
			selectSpell("iceblitz");
        }

		if(learnFireBall || learnIceBlitz)
	        if (Input.GetButtonDown("Fire1") && !playerMove.IsMoving && !playerLook.IsTurning) {
				if(playerStats.Mana >= manaCost){
					playerStats.decreaseMana(manaCost);
		            SpellCaster.castSpell(selectedSpell, playerLook.PlayerCamera.transform.position, Quaternion.Euler(0f, playerLook.Yaw, 0f));
		            PlayerMoved();
				} else{
					StartCoroutine("notifyManaUI");
				}
	        }

        if (Input.GetKeyDown(KeyCode.F)) {
			print ("interact");
            interaction.Interact();
        }
    }

    public void PlayerMoved() {
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
	public void selectSpell(string spellname){
		if (spellname.Equals ("fireball")) {
			selectedSpell = SpellBook.FireBall;
			UI_img_frostbolt_selected.enabled = false;
			UI_img_fireball_selected.enabled = true;
			manaCost = 10;
			//UI_img_frostbolt.enabled = true;
		}
		if (spellname.Equals ("iceblitz")) {
			selectedSpell = SpellBook.IceBlitz;
			UI_img_frostbolt_selected.enabled = true;
			UI_img_fireball_selected.enabled = false;
			manaCost = 10;
			//UI_img_fireball.enabled = true;
		}
	}

	public void learnSpell(string spellname){
		if (spellname.Equals ("fireball")) {
			learnFireBall = true;
			selectSpell(spellname);
			UI_img_fireball_deactivated.enabled = false;
			UI_img_fireball_selected.enabled = true;
			UI_img_fireball.enabled = true;
		}
		if (spellname.Equals ("iceblitz")) {
			learnIceBlitz = true;
			selectSpell(spellname);
			UI_img_frostbolt_deactivated.enabled = false;
			UI_img_frostbolt_selected.enabled = true;
			UI_img_frostbolt.enabled = true;
		}
	}

	IEnumerator notifyManaUI(){
		txt_notification_top.text = "Not enough mana";
		yield return new WaitForSeconds(2);
		txt_notification_top.text = "";
	}





}
