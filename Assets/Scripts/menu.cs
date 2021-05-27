using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;


public class Menu : MonoBehaviour
{
    public string levelToLoad;

    public void StartGame()
    {
        SceneManager.LoadScene("portals");
    }

    public void Quit()
    {
        Application.Quit();
    }

}