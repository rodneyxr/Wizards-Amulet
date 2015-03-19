using UnityEngine;
using System.Collections;

public class SpellTome :MonoBehaviour,IInteractable {
	public string spellname;
	Player player;

	public void Interact(){
		print ("Interact with spelltome");
		player = GameObject.Find ("Player").GetComponent<Player>();
		//get spellbook game object then trigger boolean that enables firespell
		if (spellname.Equals ("fireball"))
			player.LearnFireBall = true;
		if (spellname.Equals ("iceblitz"))
			player.LearnIceBlitz = true;

		//TODO: UI Information - You have learned firespell!

		//delete the book?

	}
}
