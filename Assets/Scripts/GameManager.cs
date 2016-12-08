using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour {
    public GameObject Enemy;
    public GameObject GameCamera;
    public float SpawnTime = 3f;
    public Transform[] SpawnPoints;
    public int Score;
    public GameObject EndGameMenu;
    public int numPlayers = 0;
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
    public void PlayerDied()
    {
            GameCamera.SetActive(true);
            numPlayers--;
            CheckGameOver();
            
    }
    public void CheckGameOver()
    {
       
        if (numPlayers <= 0)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        EndGameMenu.SetActive(true);
        Debug.Log("GameOver");
        var zombies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(var zombie in zombies)
        {
            NetworkServer.Destroy(zombie);
        }
    }

}
