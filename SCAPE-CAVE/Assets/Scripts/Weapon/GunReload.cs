using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunReload : MonoBehaviour
{

    private int maxClipAmmo = 10;
    private int mainAmmo;
    private int ammoCargador;

    public GameObject cargando;
    public GameObject mira;

    public float reloadTime = 1f; // Tiempo de recarga

    private bool isReloading = false; 
    public TMP_Text municion;
    public TMP_Text cargador;
    int numero;

    private void Update()
    {
        if (isReloading)
            return;

        // Si se presiona el boton de recarga y no se está recargando
        if (Input.GetButtonDown("Reload"))
        {
            Debug.Log("Recargando "+numero.ToString());
            numero++;
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        cargando.gameObject.SetActive(true);
        mira.gameObject.SetActive(false);
        isReloading = true;

        mainAmmo = GameManager.Instance.gunAmmo;
        ammoCargador = GameManager.Instance.ammoCargador;
        // Esperar por el tiempo de recarga
        yield return new WaitForSeconds(reloadTime);
        cargando.gameObject.SetActive(false);
        mira.gameObject.SetActive(true);
        // Calcular cuantas balas se pueden recargar
        int bulletsToReload = Mathf.Min(maxClipAmmo - mainAmmo, ammoCargador);

        // Restar las balas recargadas de la municion principal
        GameManager.Instance.ammoCargador -= bulletsToReload;

        // Sumar las balas recargadas al cargador
        GameManager.Instance.gunAmmo += bulletsToReload;

        string Tammo = GameManager.Instance.gunAmmo.ToString();
        string Tcargador = GameManager.Instance.ammoCargador.ToString();
        municion.text = Tammo;
        cargador.text = Tcargador;

        isReloading = false;
    }
}
