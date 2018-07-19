using UnityEngine;
using System.Collections;
namespace A05sj1948
{

    //make all health bars to face towards camera
    public class Board : MonoBehaviour
    {

        void Update()
        {
            transform.LookAt(Camera.main.transform);
        }
    }
}
