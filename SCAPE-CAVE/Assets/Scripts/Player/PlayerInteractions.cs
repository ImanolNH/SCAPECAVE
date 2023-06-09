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

        }
    }

}
