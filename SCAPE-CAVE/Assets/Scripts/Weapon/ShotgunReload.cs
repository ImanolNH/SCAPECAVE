using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShotgunReload : MonoBehaviour
{

    private int maxClipAmmo = 5;
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

        GameManager.Instance.shotgunReload = true;
        cargando.gameObject.SetActive(true);
        mira.gameObject.SetActive(false);

        mainAmmo = GameManager.Instance.shotgunAmmo;
        ammoCargador = GameManager.Instance.shotgunAmmoCargador;
        yield return new WaitForSeconds(reloadTime);
        cargando.gameObject.SetActive(false);
        mira.gameObject.SetActive(true);

        int bulletsToReload = Mathf.Min(maxClipAmmo - mainAmmo, ammoCargador);
        GameManager.Instance.shotgunAmmoCargador -= bulletsToReload;
        GameManager.Instance.shotgunAmmo += bulletsToReload;
        string Tammo = GameManager.Instance.shotgunAmmo.ToString();
        string Tcargador = GameManager.Instance.shotgunAmmoCargador.ToString();
        municion.text = Tammo;
        cargador.text = Tcargador;
        GameManager.Instance.shotgunReload = false;
        isReloading = false;
    }
}
