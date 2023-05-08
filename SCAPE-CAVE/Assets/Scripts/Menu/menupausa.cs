using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public static bool JuegoPausado = false;

    public GameObject menuPausa;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (JuegoPausado)
            {
                Reaundar();
            }else
            {
                Pausar();
            }
        }
    }

    public void Reaundar()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1;
        JuegoPausado = false;
    }

    public void Pausar()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0;
        JuegoPausado = true;
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Salir...");
    }
}
