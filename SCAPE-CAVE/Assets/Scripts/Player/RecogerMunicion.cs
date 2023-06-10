using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RecogerMunicion : MonoBehaviour
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

        if (other.gameObject.CompareTag("Player") && GameManager.Instance.shotgun == false)
        {
            if(GameManager.Instance.gunAmmo==10 && GameManager.Instance.ammoCargador==10) {
                instrucc = "La munición está al máximo";
                instrucciones.text = instrucc;
            }
            else
            {
                instrucc = "Pulsa 'E' para recoger la munición";
                instrucciones.text = instrucc;
                if (Input.GetKey(KeyCode.E))
                {
                    GameManager.Instance.gunAmmo += gameObject.GetComponent<AmmoBox>().ammo;

                    municionTotal = GameManager.Instance.gunAmmo;
                    //Debug.Log("Municion arma: " + municionTotal.ToString());
                    if (municionTotal > 10)
                    {   
                        GameManager.Instance.gunAmmo = 10;
                        diferenciaDeMunicion = municionTotal - 10;
                        
                        cargador = diferenciaDeMunicion + GameManager.Instance.ammoCargador;
                        if (cargador > 10)
                        {
                            cargador = 10;

                        }
                        GameManager.Instance.ammoCargador = cargador;
                        Debug.Log("Municion cargador: " + cargador);


                    }
                    instrucciones.text = "";
                    string ammo = GameManager.Instance.gunAmmo.ToString();
                    municion.text = ammo;
                    textoCargador = cargador.ToString();
                    cargadorT.text = textoCargador;
                    GameManager.Instance.cristalesRecogidos++;
                    Destroy(gameObject);
                }
            }
        }else if (other.gameObject.CompareTag("Player") && GameManager.Instance.shotgun == true)
        {
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
