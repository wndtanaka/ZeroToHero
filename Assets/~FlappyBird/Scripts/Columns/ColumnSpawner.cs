using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class ColumnSpawner : MonoBehaviour
    {
        public GameObject columnPrefab;     // The column prefab we want to spawn
        public int columnPoolSize = 5;      // How many columns to keep on standby
        public float spawnRate = 3f;        // How quickly each columns spawn
        public float columnMin = -1f;       // Minimum y value of the column
        public float columnMax = 3.5f;      // Maximum y value of the column
        public Vector3 standbyPos = new Vector3(-15, -25); // Holding position for the unused columns offscreen
        public float spawnXPos = 10f;

        GameObject[] columns; // collection of pooled columns
        int currentColumn = 0; // Indexof the cirrent column in the collection
        private float spawnTimer = 0;

        void Start()
        {
            // Initialise column pool
            columns = new GameObject[columnPoolSize];
            // loop through the collection
            for (int i = 0; i < columns.Length; i++)
            {
                columns[i] = Instantiate(columnPrefab, standbyPos, Quaternion.identity);
            }
        }
        void Update()
        {
            // Count up the time
            spawnTimer += Time.deltaTime;
            // is game not over and has spawntimer reached the spawnrate?
            if (!GameManager.Instance.gameOver && spawnTimer >= spawnRate)
            {
                // Reset timer
                spawnTimer = 0f;
                // spawn a column
                SpawnColumn();
            }
        }
        void SpawnColumn()
        {
            // set a random y spawn position for the column
            float spawnYPos = Random.Range(columnMin, columnMax);
            // get current column
            GameObject column = columns[currentColumn];
            // set the position of the current column
            column.transform.position = new Vector2(spawnXPos, spawnYPos);
            // increment value of current column
            currentColumn++;
            if (currentColumn >= columns.Length)
            {
                currentColumn = 0;
            }
        }
    }
}