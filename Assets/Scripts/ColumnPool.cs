using UnityEngine;

namespace Assets.Scripts
{
    public class ColumnPool : MonoBehaviour
    {
        public int columnPoolSize = 5;
        public GameObject columnPrefab;
        public float SpawnRate = 4f;
        public float columnMin = -1f;
        public float columnMax = 3.5f;

        private GameObject[] columns;
        private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
        private float timeSinceLastSpawned;
        private float spawnXPostion = 10f;
        private int currentColumn = 0;

        void Start()
        {
            columns = new GameObject[columnPoolSize];
            for (int i = 0; i < columnPoolSize; i++)
            {
                columns[i] = (GameObject) Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
            }
        }

        void Update()
        {
            timeSinceLastSpawned += Time.deltaTime;

            if (GameController.instance.gameOver == false && timeSinceLastSpawned >= SpawnRate)
            {
                timeSinceLastSpawned = 0;
                float spawnYPosition = Random.Range(columnMin, columnMax);
                columns[currentColumn].transform.position = new Vector2(spawnXPostion, spawnYPosition);
                currentColumn++;
                if (currentColumn >= columnPoolSize)
                {
                    currentColumn = 0;
                }
            }
        }
    }
}