using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ZombieController : NetworkBehaviour {
    private int health = 1;
    public Transform Player;

    NavMeshAgent agent;
	// Use this for initialization
	void Start () {
        var players = GameObject.FindGameObjectsWithTag("Player");
        Player = players[Random.Range(0, players.Length)].transform;

        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        /*transform.LookAt(Player);
        Vector3 direction = (Player.position - transform.position).normalized;
        GetComponent<Rigidbody>().MovePosition(transform.position + direction * Speed * Time.deltaTime);
        */
        //transform.LookAt(Player);
        agent.SetDestination(Player.position);
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().TakeDamage(20);
        }
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
