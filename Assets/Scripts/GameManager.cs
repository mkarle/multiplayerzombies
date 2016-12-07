using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour {
    public GameObject Enemy;
    public float SpawnTime = 3f;
    public Transform[] SpawnPoints;
    public int Score;
	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnEnemy", SpawnTime + 5, SpawnTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, SpawnPoints.Length);
        GameObject zombie = (GameObject)Instantiate(Enemy, SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation);
        NetworkServer.Spawn(zombie);
    }

    public void AddScore()
    {
        Score++;
        ScoreManager.score = Score;
    }

    public void CheckGameOver()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");
        if(players.Length == 0)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        var zombies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(var zombie in zombies)
        {
            NetworkServer.Destroy(zombie);
        }
    }
}
