using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrado : MonoBehaviour
{
    public puertaEsqueletos pE;
    public puertaEsqueletos pE2;

    // Start is called before the first frame update
    void Start()
    {
        GameObject puertaSuperior = GameObject.Find("PuertaSup");
        pE = puertaSuperior.GetComponent<puertaEsqueletos>();
        GameObject puertaInferior = GameObject.Find("PuertaInf");
        pE2 = puertaInferior.GetComponent<puertaEsqueletos>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pE.entrado = true;
            pE2.entrado = true;


        }
    }
}
