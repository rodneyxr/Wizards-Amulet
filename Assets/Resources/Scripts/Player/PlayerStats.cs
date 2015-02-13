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

	// Use this for initialization
	void Start () {
		//Give character base stats via public variables
		Health = playerHealth;
		Mana = playerMana;
		AttackDamage = playerAttackDamage;
		MoveSpeed = playerMoveSpeed;
		updateUIHealth ();
		updateUIMana ();

	}
	
	// Update is called once per frame
	void Update () {

	}

	void updateUIHealth(){
		PlayerHealthText.text = "Health : " + Health;
	}

	void updateUIMana(){
		PlayerManaText.text = "Mana : " + Mana;
	}

	override public void decreaseHealth(int healthTaken){
		Health -= healthTaken;
		updateUIHealth();
	}
	override public void increaseHealth(int healthIncreaseAmount){
		Health += healthIncreaseAmount;
		updateUIHealth ();
	}
	override public void increaseMana(int manaIncreaseAmount){
		Mana += manaIncreaseAmount;
		updateUIMana();
	}
	override public void decreaseMana (int manaCost){
		Mana -= manaCost;
		updateUIMana();
	}
}
