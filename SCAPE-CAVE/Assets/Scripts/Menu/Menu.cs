using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static bool JuegoPausado = false;

    public GameObject MenuPausa;

    void Update()
    {
        if (Input.GetButtonDown("menu"))
        {
            if (JuegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Reanudar()
    {
        MenuPausa.SetActive(false);
        Time.timeScale = 1f;
        JuegoPausado = false;
        Debug.Log("Reanudando juego...");
    }

    public void Pausar()
    {
        MenuPausa.SetActive(true);
        Time.timeScale = 0f;
        JuegoPausado = true;
        Debug.Log("Pausando juego...");
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Salir...");
    }
}
