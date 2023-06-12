using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mostrarIconosPantalla : MonoBehaviour
{
   
    public GameObject iconoInicio;


    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            iconoInicio.SetActive(true);

        }
    }
    private void OnTriggerExit()
    {
        iconoInicio.SetActive(false);
    }
}
