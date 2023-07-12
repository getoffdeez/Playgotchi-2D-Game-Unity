using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject youWinUI;
    public Button pauseButton;
    public Button resumeButton;

    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        // Set the initial visibility of the buttons
        pauseButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);

        // Add the onClick listeners for the buttons
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeGame);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if all enemies are no longer on the screen
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            ShowYouWinUI();
        }

        // Check if any enemies are still visible on the screen
        bool anyEnemyVisible = false;
        foreach (GameObject enemy in enemies)
        {
            if (IsVisibleOnScreen(enemy))
            {
                anyEnemyVisible = true;
                break;
            }
        }

        // If there are no enemies on the screen but some are still alive off-screen, show game over UI
        if (enemies.Length > 0 && !anyEnemyVisible)
        {
            ShowGameOverUI();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        pauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        pauseButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
    }

    private void ShowYouWinUI()
    {
        youWinUI.SetActive(true);
    }

    public void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    private bool IsVisibleOnScreen(GameObject obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
            return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
        }
        return false;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
