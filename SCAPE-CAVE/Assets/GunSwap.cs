using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunSwap : MonoBehaviour
{
    public GameObject weapon1;
    public GameObject weapon2;

    //texto pistola
    public GameObject gunInterface;
    public GameObject gunSight;
    public GameObject shotgunInterface;
    public GameObject shotgunSight;

    //public TMP_Text gunAmmo;
    //public TMP_Text gunMagazine;

    //texto escopeta
    //public TMP_Text shotgunAmmo;
    public TMP_Text aviso;

    public TMP_Text mensaje;

    private int indiceAActual = 0;
    private GameObject[] weapons;

    void Start()
    {
        // Agregar ambas armas al arreglo "weapons"
        weapons = new GameObject[] { weapon1, weapon2 };

        // Desactivar ambas armas al inicio
        weapon1.gameObject.SetActive(false);
        weapon2.gameObject.SetActive(false);

        // Activar la primera arma por defecto
        weapons[indiceAActual].gameObject.SetActive(true);
        GameManager.Instance.shotgun = false;
    }

    void Update()
    {
        // Intercambiar armas al presionar las teclas 1 o 2
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (GameManager.Instance.shotgunReload == true || GameManager.Instance.gunReload == true)
            {
                aviso.text = "No puedes intercambiar armas mientras recargas";
                StartCoroutine(EsperarYEliminarMensaje(1.5f));
            }
            else
            {
                mensaje.text = "";
                SwitchWeapon(0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (GameManager.Instance.gunReload == true || GameManager.Instance.shotgunReload == true)
            {
                aviso.text = "No puedes intercambiar armas mientras recargas";
                StartCoroutine(EsperarYEliminarMensaje(1.5f));
            }
            else
            {
                mensaje.text = "";
                SwitchWeapon(1);
            }
        }
    }

    void SwitchWeapon(int index)
    {
        // Desactivar el arma actual
        weapons[indiceAActual].gameObject.SetActive(false);

        // Activar el arma seleccionada
        weapons[index].gameObject.SetActive(true);

        // Actualizar el índice del arma actual
        indiceAActual = index;
        if (index == 0)
        {
            shotgunInterface.gameObject.SetActive(false);
            gunInterface.gameObject.SetActive(true);
            shotgunSight.gameObject.SetActive(false);
            gunSight.gameObject.SetActive(true);
            GameManager.Instance.shotgun = false;
        }
        else if(index == 1)
        {
            gunInterface.gameObject.SetActive(false);
            shotgunInterface.gameObject.SetActive(true);
            gunSight.gameObject.SetActive(false);
            shotgunSight.gameObject.SetActive(true);
            GameManager.Instance.shotgun = true;
        }
    }

    IEnumerator EsperarYEliminarMensaje(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        aviso.text = "";
    }
}
