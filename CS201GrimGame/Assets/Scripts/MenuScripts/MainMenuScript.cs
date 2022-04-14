// THIS SCRIPT IS TO LOAD MAIN MENU 

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Play Game Method
    public void PlayGame()
    {
        // Loads game scene when Play is clicked
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Quit Game Method
    public void QuitGame()
    {
        // Shuts down application when Quit is clicked
        Debug.Log("Application Quit!");
        Application.Quit();      
    }
}
