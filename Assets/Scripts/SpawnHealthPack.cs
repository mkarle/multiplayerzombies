// Modified from: https://unity3d.com/learn/tutorials/topics/multiplayer-networking/handling-non-player-objects?playlist=29690

using UnityEngine;
using UnityEngine.Networking;

public class SpawnHealthPack : NetworkBehaviour {

	public GameObject healthPack;
	public int numberOfHealthPacks;

	public override void OnStartServer() {
		for (int i = 0; i < numberOfHealthPacks; i++) {
			var spawnPosition = new Vector3(
				Random.Range(-8.0f, 8.0f),
				0.0f,
				Random.Range(-8.0f, 8.0f));

			var spawnRotation = Quaternion.Euler( 
				0.0f, 
				Random.Range(0,180), 
				0.0f);

			var enemy = (GameObject) Instantiate(healthPack, spawnPosition, spawnRotation);
			NetworkServer.Spawn(enemy);
		}
	}
	// TODO: maybe instead of a fixed number of health packs, we want to spawn them slowly over time?
}
