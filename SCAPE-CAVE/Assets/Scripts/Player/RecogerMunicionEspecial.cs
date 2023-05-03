using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RecogerMunicionEspecial : MonoBehaviour
{
    public TMP_Text municion;
    public TMP_Text instrucciones;
    public GameObject municionObjeto;
    string instrucc;
    public bool dentro = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            dentro = true;
            instrucc = "Pulsa 'E' para recoger la munición";
            instrucciones.text = instrucc;
            if(Input.GetKey(KeyCode.E)){
                GameManager.Instance.gunAmmo += gameObject.GetComponent<AmmoBox>().ammo;
                Destroy(municionObjeto);
                instrucciones.text = "";
                string ammo = GameManager.Instance.gunAmmo.ToString();
                municion.text = ammo;
            }
        }
    }
    private void OnTriggerExit()
    {
        instrucc = "";
        instrucciones.text = instrucc;
    }
}
