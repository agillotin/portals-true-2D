using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen2 : MonoBehaviour
{
    public void Destroy()           //Fonction pour détruire l'écran de chargement
    {
        Destroy(gameObject);        //On détruit le game Object de l'écran de chargement
    }
}