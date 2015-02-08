﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    //private CharacterController cc;
    private PlayerLook playerLook;
    private PlayerMove playerMove;
    private SpellBook selectedSpell;

    void Start() {
        //cc = GetComponent<CharacterController>();
        playerLook = GetComponent<PlayerLook>();
        playerMove = GetComponent<PlayerMove>();
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
        }
    }
}
