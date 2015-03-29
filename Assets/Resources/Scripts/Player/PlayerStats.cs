using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStats : Character {

    //public vars to set initial settings during debugging
    public int playerHealth;
    public int playerMana;
    public float playerMoveSpeed;
    public int playerAttackDamage;

    //UI Text variables
    public Text PlayerHealthText;
    public Text PlayerManaText;

	//Timer vars
	private float manaRegenTimer;

    // Use this for initialization
    void Start() {
        //Give character base stats via public variables
        Health = playerHealth;
        Mana = playerMana;
		updateTextReference ();
        AttackDamage = playerAttackDamage;
        MoveSpeed = playerMoveSpeed;
		manaRegenTimer = 0;
    }

    // Update is called once per frame
    void Update() {
		regenMana ();
		syncUI ();
    }

<<<<<<< HEAD
	void regenMana(){
		if (Mana < 100) {
			manaRegenTimer += Time.deltaTime;
			if (manaRegenTimer >= 3) {
					increaseMana (5);
					manaRegenTimer = 0;
			}
		}
	}
	void syncUI(){
		PlayerHealthText.text = "Health : " + Health;
		PlayerManaText.text = "Mana : " + Mana;
=======
	void updateTextReference(){
		PlayerHealthText = GameObject.Find ("Health").GetComponent<Text>();
		PlayerManaText = GameObject.Find ("Mana").GetComponent<Text>();
>>>>>>> origin/SeanBranch
	}
}
