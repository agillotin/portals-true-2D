using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen2 : MonoBehaviour
{
    public void Destroy()           //Fonction pour d�truire l'�cran de chargement
    {
        Destroy(gameObject);        //On d�truit le game Object de l'�cran de chargement
    }
}