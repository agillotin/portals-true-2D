using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{

    [SerializeField] GameObject loadingScreenPrefab;               //On récupère le game object de l'écran de chargement


    public void LoadSceneAsync()                                      //Fonction pour charger la scène de jeu en fond pendant qu'on affiche l'écran de chargement
    {
        StartCoroutine(LoadingScreenCoroutine());                        //On lance une coroutine pour l'écran de chargement
    }
    private IEnumerator LoadingScreenCoroutine()
    {
        var prefab = Instantiate(loadingScreenPrefab);                     //On stocke le préfab de l'écran de chargement
        DontDestroyOnLoad(prefab);                                         //On empeche la destruction d' l'écran de chargement lors du changement de scène
        var sceneLoading = SceneManager.LoadSceneAsync("portals");         //On stocke dans la variable sceneLoading, la scène du jeu qui se charge en arrière plan
        sceneLoading.allowSceneActivation = false;                         //On interdit à la scène du jeu de se lancer
        while (sceneLoading.isDone == false)                               //Tant que la scène de jeu n'est pas chargée
        {
            if (sceneLoading.progress >= 0.9f)                                   //Si le chargement de la scène de jeu est terminé
            {
                sceneLoading.allowSceneActivation = true;                        //On autorise la scène du jeu à se lancer
                prefab.GetComponent<Animator>().SetTrigger("disparaitre");       //On lance l'animation "disparaitre" (fondu) de l'écran de chargement
            }
            yield return new WaitForSeconds(1);                                  //On attend une seconde
        }
    }
}