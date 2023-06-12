using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RequisitosTroll : MonoBehaviour
{
    public TMP_Text instrucciones;
    string instrucc;
    public string textoVacio;
    public bool pisando = false;
    public EnemigoTroll eT;


    // Start is called before the first frame update
    void Start()
    {
        GameObject eTr = GameObject.Find("troll 1");
        eT = eTr.GetComponent<EnemigoTroll>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (eT.vidas > 0)
        {
            if (other.gameObject.CompareTag("Player") && GameManager.Instance.enemigosEliminados >= 6)
            {
                pisando = true;

            }
            else if (other.gameObject.CompareTag("Player") && GameManager.Instance.enemigosEliminados < 6)
            {

                instrucc = "Necesitas eliminar al menos a 6 enemigos para acceder";
                instrucciones.text = instrucc;

            }
        }
    }
    private void OnTriggerExit()
    {
        pisando = false;
        textoVacio = "";
        instrucciones.text = textoVacio;
    }
}
