using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puertaEsqueletos : MonoBehaviour
{
    public Animation animacion;
    bool animacionEjecutada = false;
    public bool entrado = false;
    public GameObject spawns;
    public GameObject sliderTiempo;
    private void Update()
    {
        if (GameManager.Instance.cristalesRecogidos == 3 && animacionEjecutada == false)
        {
            animacion.Play();
            animacionEjecutada = true;
        }else if (entrado == true)
        {
            animacion[animacion.clip.name].speed = -0.05f;
            animacion.Play();
            spawns.SetActive(true);
            sliderTiempo.SetActive(true);
            entrado = false;
        }

    }

    public void Final_Ani()
    {
        //ani.SetBool("abrirPuerta", false);
    }
}
