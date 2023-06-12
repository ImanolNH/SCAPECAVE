using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MensajeTroll : MonoBehaviour
{
    public TMP_Text instrucciones;
    public string instrucc;
    public string textoVacio;
    public PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        GameObject jugador = GameObject.Find("Player");
        pm = jugador.GetComponent<PlayerMovement>();
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            pm.speed = 1.5f;
            instrucciones.text = instrucc;

        }
    }
    private void OnTriggerExit()
    {
        pm.speed = 5f;
        instrucc = "";
        instrucciones.text = instrucc;
    }
}
