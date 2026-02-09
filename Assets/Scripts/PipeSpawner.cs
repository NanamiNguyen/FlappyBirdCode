using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 2f;
    public float pipeSpeed = 2f;
    public float minY = -1f;
    public float maxY = 2f;

    void Start()
    {
        InvokeRepeating("SpawnPipe", 0f, spawnRate);
    }

    void SpawnPipe()
    {
        if (!GameManager.Instance.gameStarted) return;

        float randomY = Random.Range(minY, maxY);
        GameObject pipe = Instantiate(pipePrefab, new Vector3(3, randomY, 0), Quaternion.identity);
        Destroy(pipe, 6f); // Auto-destroy after moving off screen
    }

    void Update()
    {
        if (!GameManager.Instance.gameStarted) return;

        // Move all pipes left
        foreach (GameObject pipe in GameObject.FindGameObjectsWithTag("Pipe"))
        {
            pipe.transform.position += Vector3.left * pipeSpeed * Time.deltaTime;
        }
    }
}
