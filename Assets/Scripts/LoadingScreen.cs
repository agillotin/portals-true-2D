using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{

    [SerializeField] GameObject loadingScreenPrefab;               //On r�cup�re le game object de l'�cran de chargement


    public void LoadSceneAsync()                                      //Fonction pour charger la sc�ne de jeu en fond pendant qu'on affiche l'�cran de chargement
    {
        StartCoroutine(LoadingScreenCoroutine());                        //On lance une coroutine pour l'�cran de chargement
    }
    private IEnumerator LoadingScreenCoroutine()
    {
        var prefab = Instantiate(loadingScreenPrefab);                     //On stocke le pr�fab de l'�cran de chargement
        DontDestroyOnLoad(prefab);                                         //On empeche la destruction d' l'�cran de chargement lors du changement de sc�ne
        var sceneLoading = SceneManager.LoadSceneAsync("portals");         //On stocke dans la variable sceneLoading, la sc�ne du jeu qui se charge en arri�re plan
        sceneLoading.allowSceneActivation = false;                         //On interdit � la sc�ne du jeu de se lancer
        while (sceneLoading.isDone == false)                               //Tant que la sc�ne de jeu n'est pas charg�e
        {
            if (sceneLoading.progress >= 0.9f)                                   //Si le chargement de la sc�ne de jeu est termin�
            {
                sceneLoading.allowSceneActivation = true;                        //On autorise la sc�ne du jeu � se lancer
                prefab.GetComponent<Animator>().SetTrigger("disparaitre");       //On lance l'animation "disparaitre" (fondu) de l'�cran de chargement
            }
            yield return new WaitForSeconds(1);                                  //On attend une seconde
        }
    }
}