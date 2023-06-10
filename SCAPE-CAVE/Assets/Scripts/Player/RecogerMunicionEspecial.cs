using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RecogerMunicionEspecial : MonoBehaviour
{
    public TMP_Text municion;
    public TMP_Text cargadorT;
    public TMP_Text instrucciones;
    string instrucc;

    private int municionTotal;

    private string textoCargador;
    private int diferenciaDeMunicion;
    private int cargador;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && GameManager.Instance.shotgun==true)
        {
            if (GameManager.Instance.shotgunAmmo == 5 && GameManager.Instance.shotgunAmmoCargador == 5)
            {
                instrucc = "La munición está al máximo";
                instrucciones.text = instrucc;
            }
            else
            {
                instrucc = "Pulsa 'E' para recoger la munición";
                instrucciones.text = instrucc;
                if (Input.GetKey(KeyCode.E))
                {
                    GameManager.Instance.shotgunAmmo += gameObject.GetComponent<SpecialAmmoBox>().ammo;

                    municionTotal = GameManager.Instance.shotgunAmmo;
                    Debug.Log("Municion:  " + municionTotal.ToString());
                    if (municionTotal > 5)
                    {
                        GameManager.Instance.shotgunAmmo = 5;
                        diferenciaDeMunicion = municionTotal - 5;

                        cargador = diferenciaDeMunicion + GameManager.Instance.shotgunAmmoCargador;
                        if (cargador > 5)
                        {
                            cargador = 5;

                        }
                        GameManager.Instance.shotgunAmmoCargador = cargador;


                    }
                    instrucciones.text = "";
                    string ammo = GameManager.Instance.shotgunAmmo.ToString();
                    municion.text = ammo;
                    textoCargador = cargador.ToString();
                    cargadorT.text = textoCargador;
                    GameManager.Instance.cristalesRecogidos++;
                    Destroy(gameObject);
                }
            }
        }else if(other.gameObject.CompareTag("Player") && GameManager.Instance.shotgun == false){

            instrucc = "No puedes acceder a esta munición con esta arma";
            instrucciones.text = instrucc;

        }
    }
    private void OnTriggerExit()
    {
        instrucc = "";
        instrucciones.text = instrucc;
    }
}
