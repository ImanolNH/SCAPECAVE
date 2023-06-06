using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionamientoCCristales : MonoBehaviour
{
    public GameObject[] arrayCristales = new GameObject[3];

    public GameObject columna1;
    public GameObject columna2;
    public GameObject columna3;

    public FuncionamientoColumna c1;
    public FuncionamientoColumna c2;
    public FuncionamientoColumna c3;

    void Start()
    {
        c1 = columna1.GetComponent<FuncionamientoColumna>();


        c2 = columna2.GetComponent<FuncionamientoColumna>();
        c2.gameObject.SetActive(false);

        c3 = columna3.GetComponent<FuncionamientoColumna>();
        c3.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        validarColumna();
        
    }

    public void validarColumna()
    {
        if (c1.destruida==true)
        {
            c2.gameObject.SetActive(true);
        }if(c2.destruida==false) { 
            
            c3.gameObject.SetActive(true);
        }
    }
}
