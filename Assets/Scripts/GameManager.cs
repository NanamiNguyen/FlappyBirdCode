using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton for global access
    public bool gameStarted = false;
    public GameObject getReadyUI;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        // Start the game on Space key
        if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            gameStarted = true;
            getReadyUI.SetActive(false); // Hide "Get Ready" text
        }
    }

    public void GameOver()
    {
        gameStarted = false;
        Debug.Log("Game Over!");
        // Later: Show restart button or reload scene
    }
}
