using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class RepeatObject : MonoBehaviour
    {
        public float padding = 0.01f;

        BoxCollider2D box;
        float width;

        // Use this for initialization
        void Start()
        {
            // get box collider component
            box = GetComponent<BoxCollider2D>();
            // store size of collider along horizontal axis
            width = box.size.x * transform.localScale.x;
        }

        // Update is called once per frame
        void Update()
        {
            // store the position in a smaller variable
            Vector3 pos = transform.position;
            // is the position on the x outside of the camera?
            if (pos.x < -width)
            {
                // repeat the object
                Repeat();
            }
        }
        void Repeat()
        {
            // Offset of the ground  to be placed outside the screen
            Vector3 groundOffset = new Vector3((width - padding) * 2, 0, 0);
            transform.position += groundOffset;
        }
    }

}