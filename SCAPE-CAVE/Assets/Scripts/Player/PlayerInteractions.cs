using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerInteractions : MonoBehaviour
{
    public TMP_Text municion;
    public int vidas;

    public int numero;

    public puertaEsqueletos pE;
    public puertaEsqueletos pE2;

    void Start()
    {
        GameObject puertaSuperior = GameObject.Find("PuertaSupE");
        pE = puertaSuperior.GetComponent<puertaEsqueletos>();
        GameObject puertaInferior = GameObject.Find("PuertaInfE");
        pE2 = puertaInferior.GetComponent<puertaEsqueletos>();
    }

    private void OnTriggerEnter(Collider other) {
        
        /*if(other.gameObject.CompareTag("GunAmmo"))
        {
            GameManager.Instance.gunAmmo +=other.gameObject.GetComponent<AmmoBox>().ammo;
            Destroy(other.gameObject);

            string ammo = GameManager.Instance.gunAmmo.ToString();
            municion.text = ammo;
        }else */
        if(other.CompareTag("arma")){
            
            GameManager.Instance.vidas--;
            
            numero++;

            if(GameManager.Instance.vidas == 0)
            {
                GameManager.Instance.sinVidas = true;

                SceneManager.LoadScene("MenuFinal");
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                //Destroy(gameObject);
            }

            Debug.Log("daño" + numero.ToString() + " vidas " + GameManager.Instance.vidas.ToString() + "sin vidas:" + GameManager.Instance.sinVidas.ToString());

        }else if (other.CompareTag("puerta"))
        {
            pE.entrado = true;
            pE2.entrado = true;
            Debug.Log("puerta cerrando");


        }
    }

}
