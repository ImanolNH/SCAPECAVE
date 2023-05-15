using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public static bool JuegoPausado = false;

    [SerializeField] GameObject MenuPausa;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (JuegoPausado)
            {
                Reaundar();
            }
            else
            {
                Salir();
            }
        }
    }

    public void Reaundar()
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
