using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public static bool JuegoPausado = false;

    public GameObject MenuPausa;

    public TMP_Text vidas;

    public TMP_Text gunAmmo;
    public TMP_Text cargadorGunAmmo;   
    public TMP_Text shotgunAmmo;
    public TMP_Text cargadorShotgunAmmo;

    public GameObject contador;

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
        contador.SetActive(true);
        Time.timeScale = 1f;
        JuegoPausado = false;
        Debug.Log("Reanudando juego...");
    }

    public void Pausar()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        contador.SetActive(false);
        MenuPausa.SetActive(true);
        vidas.text=GameManager.Instance.vidas.ToString();
        gunAmmo.text=GameManager.Instance.gunAmmo.ToString();
        cargadorGunAmmo.text=GameManager.Instance.ammoCargador.ToString();
        shotgunAmmo.text=GameManager.Instance.shotgunAmmo.ToString();
        cargadorShotgunAmmo.text=GameManager.Instance.shotgunAmmoCargador.ToString();
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