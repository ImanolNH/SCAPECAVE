using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mensajesEnPantalla : MonoBehaviour
{
    public TMP_Text instrucciones;
    public string instrucc;


    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            instrucciones.text = instrucc;

        }
    }
    private void OnTriggerExit()
    {
        instrucc = "";
        instrucciones.text = instrucc;
    }
}
