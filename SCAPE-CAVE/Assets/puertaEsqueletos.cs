using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puertaEsqueletos : MonoBehaviour
{
    public Animation animacion;
    public bool animacionEjecutada = false;
    public bool entrado = false;
    public bool saliendo = false;
    public GameObject spawns;
    public GameObject areaEntrada;
    public GameObject sliderTiempo;

    public requisitosEsqueletos rE;

    void Start()
    {
        GameObject requisitosE = GameObject.Find("Requisitos");
        rE = requisitosE.GetComponent<requisitosEsqueletos>();
    }
    private void Update()
    {
        if (GameManager.Instance.cristalesRecogidos >= 3 && animacionEjecutada == false && rE.pisando==true || saliendo==true)
        {
            animacion[animacion.clip.name].speed = 1f;
            animacion.Play();
            animacionEjecutada = true;
            saliendo = false;
            Debug.Log("Saliendo");

        }else if (entrado == true)
        {
            animacion[animacion.clip.name].speed = -0.05f;
            animacion.Play();
            spawns.SetActive(true);
            sliderTiempo.SetActive(true);
            entrado = false;
            areaEntrada.SetActive(false);

            Debug.Log("subiendo.....");
        }

    }

    public void Final_Ani()
    {
        //ani.SetBool("abrirPuerta", false);
    }
}
