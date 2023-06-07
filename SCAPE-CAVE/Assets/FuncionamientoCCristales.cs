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

    public bool[] arrayColumnas = new bool[3];
    

    void Start()
    {
        arrayColumnas[0] = false;
        arrayColumnas[1] = false;
        arrayColumnas[2] = false;

        columna2.SetActive(false);
        columna3.SetActive(false);

        c1 = columna1.GetComponent<FuncionamientoColumna>();
        c2 = columna2.GetComponent<FuncionamientoColumna>();
        c3 = columna3.GetComponent<FuncionamientoColumna>();
    }

    // Update is called once per frame
    void Update()
    {
        validarColumna();
        
    }

    public void validarColumna()
    {
        if(arrayColumnas[0] == true)
        {
            columna2.SetActive(true);
        }if(arrayColumnas[1]==true) {

            columna3.SetActive(true);
        }
    }
}
