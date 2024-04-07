using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuScript : MonoBehaviour
{
    public Player player;
    public GameObject pauseMenu;
    public GameObject eqScreen;

    public GameObject[] toolTip;

    static public bool isPaused;
    private bool pause;
    private bool eq;

    public void Restart()
    {
        SceneManager.LoadScene(2);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
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
                player.ResetInput();
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
                foreach(GameObject gameObject in toolTip)
                {
                    gameObject.SetActive(false);
                }

            }
            else
            {
                player.ResetInput();
                eq = true;
                isPaused = true;
                eqScreen.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
    }
}
