using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    static private bool seenNote;

    public void EnterGame()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0 && !seenNote)
        {
            SceneManager.LoadScene(1);
            seenNote = true;
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
