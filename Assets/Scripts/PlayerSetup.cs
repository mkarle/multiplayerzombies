using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerSetup : NetworkBehaviour 
{

	[SerializeField]
	Behaviour[] nonLocalComponentsToDisable;

	// Use this for initialization
	void Start () 
	{
		if (!isLocalPlayer) {
			for (int i = 0; i < nonLocalComponentsToDisable.Length; i++) {
				nonLocalComponentsToDisable [i].enabled = false;
			}

		} else 
		{
			Camera.main.gameObject.SetActive (false);
			for (int i = 0; i < nonLocalComponentsToDisable.Length; i++) {
				nonLocalComponentsToDisable [i].enabled = true;
			}
		}
	}
}
