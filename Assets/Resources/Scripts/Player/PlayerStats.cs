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
    public Text playerHealthText;
    public Text playerManaText;
	private bool isDead;
    //Timer vars
    private float manaRegenTimer;

    // Use this for initialization
    void Start() {
        //Give character base stats via public variables
        Health = playerHealth;
        Mana = playerMana;
        updateTextReference();
        AttackDamage = playerAttackDamage;
        MoveSpeed = playerMoveSpeed;
        manaRegenTimer = 0;
		isDead = false;
	}

    // Update is called once per frame
    void Update() {
		if (Health <= 0)
			isDead = true;
		if (!isDead) {
			regenMana ();
			syncUI ();
		} else {
			death();
		}
    }

    void regenMana() {
        if (Mana < 100) {
            manaRegenTimer += Time.deltaTime;
            if (manaRegenTimer >= 3) {
                increaseMana(5);
                manaRegenTimer = 0;
            }
        }
    }

	public void gainHealth(int hp){
		Health += hp;
		if (Health > 100)
			Health = 100;
	}

    void syncUI() {
        playerHealthText.text = "Health : " + Health;
        playerManaText.text = "Mana : " + Mana;
    }
	private void death(){
		Application.LoadLevel (3);
	}
    public void updateTextReference() {
        playerHealthText = GameObject.Find("Health").GetComponent<Text>();
        playerManaText = GameObject.Find("Mana").GetComponent<Text>();

    }
}
