using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameplayScene"); // Replace with the name of your gameplay scene
    }

    public void QuitGame()
    {
        Application.Quit(); // Exits the application
        Debug.Log("Quit Game"); // Works only in the editor for testing
    }
}