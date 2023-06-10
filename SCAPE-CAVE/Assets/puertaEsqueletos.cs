using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertaEsqueletos : MonoBehaviour
{
    public Animation animacion;
    bool animacionEjecutada = false;
    public bool entrado = false;
    private void Update()
    {
        if (GameManager.Instance.cristalesRecogidos == 3 && animacionEjecutada == false)
        {
            animacion.Play();
            animacionEjecutada = true;
        }else if (entrado == true)
        {
            animacion[animacion.clip.name].speed = -1;
            animacion.Play();
            entrado = false;
        }

    }

    public void Final_Ani()
    {
        //ani.SetBool("abrirPuerta", false);
    }
}
