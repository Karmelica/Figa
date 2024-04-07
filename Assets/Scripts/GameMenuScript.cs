using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject eqScreen;
    [SerializeField] static public bool isPaused;
    private bool pause;
    private bool eq;

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void Start()
    {
        pauseMenu.SetActive(false);
        eqScreen.SetActive(false);
        isPaused = false;
        eq = false;
        pause = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !eq)
        {
            if (isPaused)
            {
                pause = false;
                isPaused = false;
                pauseMenu.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

            }
            else
            {
                pause = true;
                isPaused = true;
                pauseMenu.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab) && !pause)
        {
            if (isPaused)
            {
                eq = false;
                isPaused = false;
                eqScreen.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

            }
            else
            {
                eq = true;
                isPaused = true;
                eqScreen.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
    }
}
