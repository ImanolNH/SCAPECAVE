using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scriptCura : MonoBehaviour
{

    public TMP_Text instrucciones;
    public TMP_Text vidas;
    string instrucc;
    private float timer = 0f;

    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance.vidas == 3) {
               
                instrucc = "Vida al máximo";
                instrucciones.text = instrucc;
            }
            else { 
                timer += Time.deltaTime;
                instrucc = "Curando...";
                instrucciones.text = instrucc;
                if (timer >= 3 && GameManager.Instance.vidas < 3)
                {
                    
                    timer = 0f;
                    GameManager.Instance.vidas += 1;
                    GameManager.Instance.vidas = Mathf.Clamp(GameManager.Instance.vidas, 0, 3);
                    vidas.text = GameManager.Instance.vidas.ToString();
                    // Aquí puedes agregar código adicional para actualizar la barra de vida u otras acciones relacionadas con la curación
                    Debug.Log("Vida actual: " + GameManager.Instance.vidas.ToString());
                }
            }
        }
    }
    private void OnTriggerExit()
    {
        instrucc = "";
        instrucciones.text = instrucc;
    }

    IEnumerator tiempoCuracion(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        Debug.Log("curancioçón");
        GameManager.Instance.vidas += 1;
        

    }
}
