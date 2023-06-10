using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFinal : MonoBehaviour
{
    public void Jugar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
        Debug.Log("Reiniciando juego...");
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Salir...");
    }
}
