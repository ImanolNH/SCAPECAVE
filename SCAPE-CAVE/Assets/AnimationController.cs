using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    public Animation animacion;
    bool animacionEjecutada=false;

    public RequisitosTroll rT;

    void Start()
    {
        GameObject requisitosT = GameObject.Find("RequisitosT");
        rT = requisitosT.GetComponent<RequisitosTroll>();
    }

    private void Update()
    {
        if (animacionEjecutada==false && rT.pisando==true)
        {
            animacion.Play();
            animacionEjecutada = true;
        }
        
    }

    public void Final_Ani()
    {
        //ani.SetBool("abrirPuerta", false);
    }
}
