using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuComponentes : MonoBehaviour
{
    // Start is called before the first frame update
    public void Volver()
    {
        SceneManager.LoadScene("MenuInicial");
    }
}
