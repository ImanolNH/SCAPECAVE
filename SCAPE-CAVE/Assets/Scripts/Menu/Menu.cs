using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static bool JuegoPausado = false;

    public GameObject MenuPausa;

    void Start()
    {
        Cursor.visible = false;
    }

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
        Cursor.visible = false;
        MenuPausa.SetActive(false);
        Time.timeScale = 1f;
        JuegoPausado = false;
        Debug.Log("Reanudando juego...");
    }

    public void Pausar()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        MenuPausa.SetActive(true);
        Time.timeScale = 0f;
        JuegoPausado = true;
        Debug.Log("Pausando juego...");
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Reiniciando juego...");
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Salir...");
    }
}