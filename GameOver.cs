using UnityEngine;

public class GameOver : MonoBehaviour
{

    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject gameOverPanel;

    RocketMovementScript rocketMovementScript;

    void Start()
    {
        rocketMovementScript = GetComponent<RocketMovementScript>();
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("LandPad"))
        {
            rocketMovementScript.isRocketFly = false;
            pauseButton.SetActive(false);
            Invoke("GameOverAwake", 0.5f);
        }
    }

    void GameOverAwake()
    {
        gameOverPanel.SetActive(true);
    }
}