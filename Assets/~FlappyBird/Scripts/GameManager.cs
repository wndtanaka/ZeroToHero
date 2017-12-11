using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class GameManager : MonoBehaviour
    {
        public bool gameOver = false;
        public float scrollSpeed = -2.0f;
        public int score = 0;

        public static GameManager Instance = null;

        public delegate void ScoreAddedCallBack(int score);
        public ScoreAddedCallBack scoreAdded;

        // Use this for initialization
        void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        public void BirdScored()
        {
            // the bird cant score if there is a game over
            if (gameOver)
            {
                // exit the function
                return;
            }
            // Increase the score
            score++;
            // If there is a function subscribed
            if (scoreAdded != null)
            {
                // Call an event to state that a score has been added
                scoreAdded.Invoke(score);
            }
        }

        public void BirdDied()
        {
            gameOver = true;
        }
    }
}