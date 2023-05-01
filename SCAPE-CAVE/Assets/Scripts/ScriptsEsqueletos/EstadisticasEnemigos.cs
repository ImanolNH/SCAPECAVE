using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EstadisticasEnemigos : MonoBehaviour
{
    public int vidaEnemigo;
    public Slider barraVidaEnemigo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        barraVidaEnemigo.value = vidaEnemigo;
    }
}
