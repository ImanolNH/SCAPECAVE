using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get; private set; }

    public int gunAmmo=3;
    public int vidas = 3;

    /*public TMP_Text municionTexto;
    public estadisticas municion;*/

    private void Awake(){
        
        Instance=this;
    }

    /*public void Coleccionar()
    {
        municionTexto.text = GameManager.Instance.gunAmmo.ToString();
    }*/

}
