using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerSetup : NetworkBehaviour 
{

	[SerializeField]
	Behaviour[] nonLocalComponentsToDisable;
	bool disabled = false;
	// Use this for initialization
	void Start () 
	{
		
	}
	void Update (){
		if (!disabled) {
			if (!isLocalPlayer) {
				for (int i = 0; i < nonLocalComponentsToDisable.Length; i++) {
					if (nonLocalComponentsToDisable [i] == null) {
						
						disabled = false;
						break;
					}
					else
						nonLocalComponentsToDisable [i].enabled = false;
				}
				disabled = true;

			} else {
				GameManager.numPlayers++;
				Camera.main.gameObject.SetActive (false);
				for (int i = 0; i < nonLocalComponentsToDisable.Length; i++) {
					if (nonLocalComponentsToDisable [i] == null) {
						disabled = false;
						break;
					}
					else
						nonLocalComponentsToDisable [i].enabled = true;
				}
				disabled = true;
			}
		}
	}
}
