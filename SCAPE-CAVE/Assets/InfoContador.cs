using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoContador : MonoBehaviour
{

    public TMP_Text textoEnemigos;
    public TMP_Text textoCristales;

    void Update()
    {
        textoEnemigos.text = GameManager.Instance.enemigosEliminados.ToString();
        textoCristales.text = GameManager.Instance.cristalesRecogidos.ToString();
    }
}
