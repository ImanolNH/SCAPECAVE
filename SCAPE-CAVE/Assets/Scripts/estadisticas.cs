using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class estadisticas : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text municionTexto;
    public void Setup(int municion)
    {
        gameObject.SetActive(true);
        municionTexto.text = municion.ToString();
    }
}
