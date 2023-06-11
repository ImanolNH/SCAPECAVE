using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class requisitosEsqueletos : MonoBehaviour
{
    public TMP_Text instrucciones;
    public string instrucc;
    public bool pisando=false;


    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && GameManager.Instance.cristalesRecogidos >= 5)
        {
            pisando = true;
           
        }
        else if (other.gameObject.CompareTag("Player") && GameManager.Instance.cristalesRecogidos <5 )
        {

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
