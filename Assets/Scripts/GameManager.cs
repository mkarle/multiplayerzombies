using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameManager : NetworkBehaviour {
    public GameObject Enemy;
    public GameObject GameCamera;
    public float SpawnTime = 3f;
    public Transform[] SpawnPoints;
    public static int Score;
    public GameObject EndGameMenu;

    public static int numPlayers = 0;

	public GameObject[] SceneCameras = new GameObject[3];

	// Use this for initialization
	void Start () {
		if (!isServer) {
			return;
		}

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

	public void PlayerDied(int device)
    {	
		if (device == 0) {
			SceneCameras [0].SetActive (true);

		} else if (device == 1) {
			SceneCameras [1].SetActive (true);

		} else {
			SceneCameras [2].SetActive (true);
		}

        numPlayers--;
        CheckGameOver();         
    }

    public void CheckGameOver()
    {
       
		if (!GameObject.FindGameObjectWithTag("Player"))
        {
            EndGame();
        }
    }

    public void EndGame()
	{
		EndGameMenu.SetActive (true);
		EndGameMenu.GetComponentInChildren<Text> ().text = "GAME OVER\nSCORE:" + ScoreManager.score;

		Debug.Log ("GameOver");
		var zombies = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (var zombie in zombies) {
			Destroy (zombie);
		}
	}
}
