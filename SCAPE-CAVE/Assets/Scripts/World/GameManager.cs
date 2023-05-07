using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get; private set; }

    public int vidas = 3;
    //Munci�n Pistola
    public int gunAmmo=5;
    public int maxAmmo = 10;
    public int ammoCargador=0;

    //Munci�n Escopeta
    public int shotgunAmmo = 2;
    public int shotgunMaxAmmo = 5;
    public int shotgunAmmoCargador = 0;

    public bool shotgun = true;

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
