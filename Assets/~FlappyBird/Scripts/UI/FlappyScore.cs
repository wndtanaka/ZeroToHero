using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FlappyBird
{
    public class FlappyScore : MonoBehaviour
    {
        public Sprite[] numbers;            // Stores all the flappy digits
        public GameObject scoreTextPrefab;  // Score Prefab text element to create
        public Vector3 standbyPos = new Vector3(-15, 15); // Position offscreen for standby
        public int maxDigits = 5;

        GameObject[] scoreTextPool;
        int[] digits;

        // Use this for initialization
        void Start()
        {
            // Allocate memory for the score text pool
            scoreTextPool = new GameObject[maxDigits];
            // Loop through all available digits
            for (int i = 0; i < maxDigits; i++)
            {
                // create a new gameobject offscreen
                GameObject clone = Instantiate(scoreTextPrefab, standbyPos, Quaternion.identity);
                // get the imagecomponent
                Image img = clone.GetComponent<Image>();
                // set sprite to corresponding number sprite
                img.sprite = numbers[i];
                // attach to self
                clone.transform.SetParent(transform);
                // set name of text to index
                clone.name = i.ToString();
                // Add it to pool
                scoreTextPool[i] = clone;
            }
            // subscribe to GameManager's added score event
            GameManager.Instance.scoreAdded += UpdateScore; // ASK
            UpdateScore(0);
        }

        void UpdateScore(int score)
        {
            // convert score int array of digits
            int[] digits = GetDigits(score);
            // loop through all digits
            for (int i = 0; i < digits.Length; i++)
            {
                // get value of each digit
                int value = digits[i];
                // get corresponding text element in pool
                GameObject textElement = scoreTextPool[i];
                // get image component attached to it
                Image img = textElement.GetComponent<Image>();
                // assign sprite to number using value;
                img.sprite = numbers[value];
                // active text element
                textElement.SetActive(true);
            }
            // Loop through all remaining text elements in the pool
            for (int i = digits.Length; i < scoreTextPool.Length; i++)
            {
                // Deactivate that element
                scoreTextPool[i].SetActive(false);
            }
        }

        int[] GetDigits(int number)
        {
            List<int> digits = new List<int>();
            while (number >= 10)
            {
                digits.Add(number % 10);
                number /= 10;
            }
            digits.Add(number);
            digits.Reverse();
            return digits.ToArray();
        }
    }
}