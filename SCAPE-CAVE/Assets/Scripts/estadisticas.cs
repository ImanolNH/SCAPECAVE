using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class estadisticas : MonoBehaviour
{
    // Start is called before the first frame update
    public Text municion;
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        municion.text = municion.ToString();
    }
}
