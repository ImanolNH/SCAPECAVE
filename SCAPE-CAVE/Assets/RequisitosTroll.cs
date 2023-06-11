using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RequisitosTroll : MonoBehaviour
{
    public TMP_Text instrucciones;
    string instrucc;
    public bool pisando = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerStay(Collider other)
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
    private void OnTriggerExit()
    {
        pisando = false;
        instrucc = "";
        instrucciones.text = instrucc;
    }
}
