using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menus : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("portals");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
