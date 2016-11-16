using UnityEngine;
using UnityEngine.Networking;

public class HealthPackManager : NetworkBehaviour {

	public int restoreAmount;

	public override void OnStartServer() {
		
	}

	// TODO: how do we know when the health hack is hit?
	public void OnHit() {
		if (isLocalPlayer) {
			// TODO: how do we get the local player object?
//			playerHealth.RestoreHealth (restoreAmount);
		}
		// restores health to players by looking at the health pack and clicking the trigger
	}
	// TODO: maybe instead of a fixed number of health packs, we want to spawn them slowly over time?
}