using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    [RequireComponent(typeof(Bird))]
    public class UserInput : MonoBehaviour
    {

        Bird bird;

        // Use this for initialization
        void Start()
        {
            bird = GetComponent<Bird>();
        }

        // Update is called once per frame
        void Update()
        {
            // check for mouse down
            if (Input.GetKeyDown(KeyCode.Space))
            {
                bird.Flap();
            }
        }
    }
}