using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bird : MonoBehaviour
    {
        public float upForce; // upward force of the "flap"

        bool isDead = false; // has the player collider
        Rigidbody2D rigid;
        Animator anim;
        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        public void Flap()
        {
            // Only flap if the bird isn't dead yet
            if (!isDead)
            {
                rigid.velocity = Vector2.zero;
                // Give the brd some upward force
                rigid.AddForce(new Vector2(0, upForce), ForceMode2D.Impulse);
                anim.SetTrigger("Flap");
            }
        }
        void OnCollisionEnter2D(Collision2D other)
        {
            // cancel velocity
            rigid.velocity = Vector2.zero;
            isDead = true;
            GameManager.Instance.BirdDied();
        }
    }
}