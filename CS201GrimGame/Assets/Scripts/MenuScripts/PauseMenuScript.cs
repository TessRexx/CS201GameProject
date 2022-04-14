// THIS SCRIPT IS FOR PAUSING THE GAME AND DISPLAYING MENU OPTIONS

using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseMenuUI;
    float normalTime = 1f;
    float frozenTime = 0f;

    // Update is called once per frame
    void Update()
    {
        // If ESC pressed, then pause or unpause
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Resume Gameplay Method
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = normalTime;
        gamePaused = false;
    }

    // Pause Gameplay Method
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = frozenTime;
        gamePaused = true;
    }

    // Load Main Menu Method
    public void LoadMainMenu()
    {
        string menu = "MainMenu";
        Time.timeScale = normalTime;
        SceneManager.LoadScene(menu);
    }

    // Quit Game Method
    public void QuitGame()
    {
        // Shuts down application when Quit is clicked
        Debug.Log("Application Quit!");
        Application.Quit();
    }
}
