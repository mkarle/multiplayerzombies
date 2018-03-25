﻿a// Modified from https://unity3d.com/learn/tutorials/topics/multiplayer-networking/networking-player-health?playlist=29690
// Health script manages both players and enemies
// Check destroyOnDeath for enemies

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class CardboardHealth : Health {



	public override void TakeDamage(int amount) {
		if (!isServer) {
			return;
		}

		currentHealth -= amount;
        
		if (currentHealth <= 0) {
			if (destroyOnDeath) {
				GetComponent<PlayerController>().Die();
			} else {
				currentHealth = maxHealth;

				// called on the Server, will be invoked on the Clients
				RpcRespawn();
			}
		}
	}
		
}