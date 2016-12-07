using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ZombieController : NetworkBehaviour {
    private int health = 1;
    public Transform Player;

    NavMeshAgent agent;
	// Use this for initialization
	void Start () {
        UpdatePlayer();
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        /*transform.LookAt(Player);
        Vector3 direction = (Player.position - transform.position).normalized;
        GetComponent<Rigidbody>().MovePosition(transform.position + direction * Speed * Time.deltaTime);
        */
        //transform.LookAt(Player);
        if (Player)
        {
            agent.SetDestination(Player.position);
        }
        else
        {
            UpdatePlayer();
     
        }
	}
    private void UpdatePlayer()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");
        Player = players[Random.Range(0, players.Length)].transform;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            GetComponent<Rigidbody>().SendMessage("Hit");
        }

    }

    public void Hit()
    {
        health--;
        if(health < 1)
            Die();
    }
    void Die()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().AddScore();
        NetworkServer.Destroy(gameObject);
    }
}
