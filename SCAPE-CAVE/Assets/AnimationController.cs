using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    public Animation animacion;
    bool animacionEjecutada=false;
    private void Update()
    {
        if (GameManager.Instance.enemigosEliminados == 3 && animacionEjecutada==false)
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
