
/* 
   SHOOTING SCRIPT 
   AUTHORED BY LAUREN BUCK
   NOV 15 2016
*/

using UnityEngine;
using UnityEngine.Networking;

public class Shooting_Script : NetworkBehaviour {

    public GameObject bullet;
    public Transform spawnBullet;

    void Update()
    {
        // if we are not the local player do not execute this script
        if (!isLocalPlayer)
            return;

        if (Input.GetKeyDown(KeyCode.Space) ||  // unity editor testing
            Input.GetButtonDown("Fire1"))       // google cardboard trigger
            FireBullet();
    }

    [Command]   // makes this function a networking command
    void FireBullet()
    {

    }

}
