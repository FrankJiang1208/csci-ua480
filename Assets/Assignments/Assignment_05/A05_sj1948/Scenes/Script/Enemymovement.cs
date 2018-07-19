using UnityEngine;
using UnityEngine.Networking;

public class Enemymovement : NetworkBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public int countdown=150;

    void Update()
    {


        //controls the rotation and the speed of the enemies at random
        float x = Random.Range(-2f ,2f) * Time.deltaTime * 150.0f;
        float z = Random.Range(0, 1f) * Time.deltaTime * 2.0f;

        if (Mathf.Abs(transform.position.x) <= 9 && Mathf.Abs(transform.position.z) <= 9)
        {
            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);
        }
        else
        {
            //Make sure the minions turn around before they hit the boarder
            transform.Rotate(new Vector3(0, 180, 0));
            transform.Translate(0, 0, z);
        }
        //Controls the time of when the minions fire
        if(countdown==0){
            CmdFire();
            countdown = 150;
        }
            
        countdown--;
    }

    // This [Command] code is called on the Client …
    // … but it is run on the Server!
    [Command]
    void CmdFire()
    {
     
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 2;

        // Spawn the bullet on the Clients
        NetworkServer.Spawn(bullet);

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }


}