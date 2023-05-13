using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShotgunReload : MonoBehaviour
{

    private int maxClipAmmo = 10;
    private int mainAmmo;
    private int ammoCargador;

    public GameObject cargando;
    public GameObject mira;

    public float reloadTime = 2f; // Tiempo de recarga

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
            Debug.Log("Recargando " + numero.ToString());
            numero++;
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        cargando.gameObject.SetActive(true);
        mira.gameObject.SetActive(false);
        mainAmmo = GameManager.Instance.shotgunAmmo;
        ammoCargador = GameManager.Instance.shotgunAmmoCargador;
        // Esperar por el tiempo de recarga
        yield return new WaitForSeconds(reloadTime);
        cargando.gameObject.SetActive(false);
        mira.gameObject.SetActive(true);
        // Calcular cuantas balas se pueden recargar
        int bulletsToReload = Mathf.Min(maxClipAmmo - mainAmmo, ammoCargador);

        // Restar las balas recargadas de la municion principal
        GameManager.Instance.shotgunAmmoCargador -= bulletsToReload;

        // Sumar las balas recargadas al cargador
        GameManager.Instance.shotgunAmmo += bulletsToReload;

        string Tammo = GameManager.Instance.shotgunAmmo.ToString();
        string Tcargador = GameManager.Instance.shotgunAmmoCargador.ToString();
        municion.text = Tammo;
        cargador.text = Tcargador;

        isReloading = false;
    }
}
