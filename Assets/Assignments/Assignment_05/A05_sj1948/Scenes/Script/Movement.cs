using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace A05sj1948
{
    public class Movement :NetworkBehaviour
    {

        public float speed;
        public GameObject bulletPrefab;
        public Transform bulletSpawn;

        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
                    //Allows the player to be constantly moving where it is facing
                    Vector3 forward = Camera.main.transform.forward;
                    forward.y = 0;
                    transform.Translate(forward * speed * Time.deltaTime);

            //press the button to fire
            if (Input.GetMouseButton(0) )
            {

                CmdFire();
            }

        }
        [Command]
        void CmdFire()
        {


            // Create the Bullet from the Bullet Prefab
            var bullet = (GameObject)Instantiate(
                bulletPrefab,
                bulletSpawn.position,
                bulletSpawn.rotation);
            
            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 5;

            // Spawn the bullet on the Clients
            NetworkServer.Spawn(bullet);

            // Destroy the bullet after 2 seconds
            Destroy(bullet, 2.0f);
        }
    }
}
