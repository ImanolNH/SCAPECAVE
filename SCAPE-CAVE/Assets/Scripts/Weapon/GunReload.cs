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

        if (Input.GetButtonDown("Reload"))
        {
            Debug.Log("Recargando "+numero.ToString());
            numero++;
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        isReloading = true;

        GameManager.Instance.gunReload = true;
        cargando.gameObject.SetActive(true);
        mira.gameObject.SetActive(false);


        mainAmmo = GameManager.Instance.gunAmmo;
        ammoCargador = GameManager.Instance.ammoCargador;
        yield return new WaitForSeconds(reloadTime);

        cargando.gameObject.SetActive(false);
        mira.gameObject.SetActive(true);
        int bulletsToReload = Mathf.Min(maxClipAmmo - mainAmmo, ammoCargador);

        GameManager.Instance.ammoCargador -= bulletsToReload;

        GameManager.Instance.gunAmmo += bulletsToReload;

        string Tammo = GameManager.Instance.gunAmmo.ToString();
        string Tcargador = GameManager.Instance.ammoCargador.ToString();
        municion.text = Tammo;
        cargador.text = Tcargador;

        GameManager.Instance.gunReload = false;

        isReloading = false;
    }
}
