using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject gamePausePanel;
    [SerializeField] GameObject gameStartPanel;
    [SerializeField] GameObject gameOverPanel;

    void Awake()
    {
        Time.timeScale = 0;
    }

    public void GameStart()
    {
        Time.timeScale = 1;
        gameStartPanel.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void GamePause()
    {
        Time.timeScale = 0;
        gamePausePanel.SetActive(true);
    }

    public void GameContinue()
    {
        Time.timeScale = 1;
        gamePausePanel.SetActive(false);
    }

    public void GameRestart()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
