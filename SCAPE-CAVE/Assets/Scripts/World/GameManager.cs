using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get; private set; }

    public int vidas = 3;
    //Munción Pistola
    public int gunAmmo=5;
    public int ammoCargador=0;
    public bool gunReload = false;

    //Munción Escopeta
    public int shotgunAmmo = 2;
    public int shotgunAmmoCargador = 0;
    public bool shotgunReload=false;

    public bool shotgun = true;
    public bool sinVidas = false;

    public int enemigosEliminados = 0;

    public int cristalesRecogidos = 0;
     

    private void Awake(){
        Instance=this;
    }

}
