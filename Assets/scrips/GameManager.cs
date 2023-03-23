using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI Puntos;
    public int contador;

    void Update()
    {
        if (!GameObject.FindWithTag("Player"))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void ActualizarPuntos()
    {
        contador = contador + 1;
        Puntos.text = contador.ToString();
    }
}