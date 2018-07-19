using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
namespace A05sj1948
{
    public class GetRotation : MonoBehaviour
    {


        //Maker sure that the player model turns as the camera turns
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void LateUpdate()
        {
            Vector3 Cam = Camera.main.transform.localRotation.eulerAngles;
            Quaternion rotation = Quaternion.Euler(0, Cam.y, 0);
            transform.rotation = rotation;
        }

    }
}
