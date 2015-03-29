using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpellTome :MonoBehaviour,IInteractable {
	public string spellname;
	public Text UI_Notify;
	Player player;
	bool hasInteracted;
	Transform leftbook;
	Transform rightbook;	
	void Start(){
		hasInteracted = false;
		leftbook = gameObject.transform.parent.GetChild(0);
		rightbook = gameObject.transform.parent.GetChild(1);


	}

	public void Interact(){
		if (!hasInteracted) {
			player = GameObject.Find ("Player(Clone)").GetComponent<Player> ();
			//get spellbook game object then trigger boolean that enables firespell
			if (spellname.Equals ("fireball"))
				player.learnSpell("fireball");
			if (spellname.Equals ("iceblitz"))
				player.learnSpell("iceblitz");

			//delete the book?
			Destroy(leftbook.gameObject);
			Destroy(rightbook.gameObject);
			hasInteracted = true;
			//TODO: UI Information - You have learned firespell!
			StartCoroutine ("notifyUI");

		}
	}

	IEnumerator notifyUI(){
		UI_Notify.text = "You have learned a new spell: "+spellname;
		yield return new WaitForSeconds(3);
		UI_Notify.text = "";
	}
}
