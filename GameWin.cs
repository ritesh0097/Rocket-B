using UnityEngine;

public class GameWin : MonoBehaviour
{
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject gameWinPanel;

    RocketMovementScript rocketMovementScript;

    void Start()
    {
        rocketMovementScript = GetComponent<RocketMovementScript>();
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("LandPad"))
        {
            rocketMovementScript.isRocketFly = false;
            pauseButton.SetActive(false);
            Invoke("GameOverAwake", 0.5f);
        }
    }

    void GameOverAwake()
    {
        gameWinPanel.SetActive(true);
    }
}
