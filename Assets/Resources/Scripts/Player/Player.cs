using UnityEngine;
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
    private RawImage UI_img_fireball;
    private RawImage UI_img_fireball_selected;
    private RawImage UI_img_fireball_deactivated;
    private RawImage UI_img_frostbolt;
    private RawImage UI_img_frostbolt_selected;
    private RawImage UI_img_frostbolt_deactivated;
    private Text txt_notification_top;

    void Start() {
        //cc = GetComponent<CharacterController>();
        playerStats = GetComponent<PlayerStats>();//GameObject.Find("Player(Clone)").GetComponent<PlayerStats>();
        updateTextReference();
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

        if (learnFireBall || learnIceBlitz)
            if (Input.GetButtonDown("Fire1") && !playerMove.IsMoving && !playerLook.IsTurning && playerTurn) {
                if (playerStats.Mana >= manaCost) {
                    playerStats.decreaseMana(manaCost);
                    SpellCaster.castSpell(selectedSpell, playerLook.PlayerCamera.transform.position, Quaternion.Euler(0f, playerLook.Yaw, 0f));
                    EndTurn();
                } else {
                    StartCoroutine("notifyManaUI");
                }
            }

        if (Input.GetKeyDown(KeyCode.F)) {
            interaction.Interact();
        }
    }

    public void EndTurn() {
        PlayerTurn = false;
    }

    public void StartTurn() {
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
    public void selectSpell(string spellname) {
        if (spellname.Equals("fireball")) {
            selectedSpell = SpellBook.FireBall;
            UI_img_frostbolt_selected.enabled = false;
            UI_img_fireball_selected.enabled = true;
            manaCost = 10;
            //UI_img_frostbolt.enabled = true;
        }
        if (spellname.Equals("iceblitz")) {
            selectedSpell = SpellBook.IceBlitz;
            UI_img_frostbolt_selected.enabled = true;
            UI_img_fireball_selected.enabled = false;
            manaCost = 10;
            //UI_img_fireball.enabled = true;
        }
    }

    public void learnSpell(string spellname) {
        if (spellname.Equals("fireball")) {
            learnFireBall = true;
            selectSpell(spellname);
            UI_img_fireball_deactivated.enabled = false;
            UI_img_fireball_selected.enabled = true;
            UI_img_fireball.enabled = true;
        }
        if (spellname.Equals("iceblitz")) {
            learnIceBlitz = true;
            selectSpell(spellname);
            UI_img_frostbolt_deactivated.enabled = false;
            UI_img_frostbolt_selected.enabled = true;
            UI_img_frostbolt.enabled = true;
        }
    }

    IEnumerator notifyManaUI() {
        txt_notification_top.text = "Not enough mana";
        yield return new WaitForSeconds(2);
        txt_notification_top.text = "";
    }

    public void updateTextReference() {
        UI_img_fireball = GameObject.Find("img_fireball").GetComponent<RawImage>();
        UI_img_fireball_selected = GameObject.Find("img_fireball_selected").GetComponent<RawImage>();
        UI_img_fireball_deactivated = GameObject.Find("img_fireball_deactivated").GetComponent<RawImage>();
        UI_img_frostbolt = GameObject.Find("img_frostbolt").GetComponent<RawImage>();
        UI_img_frostbolt_selected = GameObject.Find("img_frostbolt_selected").GetComponent<RawImage>();
        UI_img_frostbolt_deactivated = GameObject.Find("img_frostbolt_deactivated").GetComponent<RawImage>();
        txt_notification_top = GameObject.Find("txt_notification_top").GetComponent<Text>();

    }

}
