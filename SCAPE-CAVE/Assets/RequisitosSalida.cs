using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RequisitosSalida : MonoBehaviour
{
    public TMP_Text instrucciones;
    public string instrucc;
    public string textoVacio;
    public PlayerMovement pm;
    public EnemigoTroll eT;


    void Start()
    {
        GameObject eTr = GameObject.Find("troll 1");
        eT = eTr.GetComponent<EnemigoTroll>();

    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            if (eT.vidas> 0){
                
                instrucc = "Necesitas matar al Jefe de la cueva para poder escapar";
                instrucciones.text = instrucc;
            }

        }
        
    }
    private void OnTriggerExit()
    {
        textoVacio = "";
        instrucciones.text = textoVacio;
    }
}
