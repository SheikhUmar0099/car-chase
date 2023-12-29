using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }
    // Function to be called when the "Shop" button is clicked
    public void OnShopButtonClick()
    {
        // Replace "ShopScene" with the actual name of your shop scene
        SceneManager.LoadScene("ShopScene");
    }

    // Function to be called when the "Game" button is clicked
    public void OnGameButtonClick()
    {
        // Replace "GameScene" with the actual name of your game scene
        SceneManager.LoadScene("GameScene");
    }

    public void BackFomShopToMenu()
    {
        SceneManager.LoadScene("menu");
    }
    
    public void OnPauseButtonClick()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnResumeButtonClick()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
