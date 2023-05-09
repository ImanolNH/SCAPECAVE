using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bullet;

    public float shotForce=700f;
    public float shotRate =0.5f;
    
    private float shotRateTime =0;

    // Start is called before the first frame update

    public TMP_Text municion;
    public TMP_Text cargador;

    public TMP_Text mensaje;

    private bool mensajeMostrado = false;
    //public estadisticas municion;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (GameManager.Instance.gunAmmo == 0 && GameManager.Instance.ammoCargador ==0) {

                if (!mensajeMostrado)
                {
                    mensaje.text = "No hay munición";
                    StartCoroutine(EsperarYEliminarMensaje(2f));
                    mensajeMostrado = true;
                }

            }
            else if(GameManager.Instance.gunAmmo == 0 && GameManager.Instance.ammoCargador > 0)
            {
                if (!mensajeMostrado)
                {
                    mensaje.text = "Debes recargar munición";
                    StartCoroutine(EsperarYEliminarMensaje(2f));
                    mensajeMostrado = true;
                }
            }
            else
            {
                if (Time.time > shotRateTime && GameManager.Instance.gunAmmo > 0)
                {
                    GameManager.Instance.gunAmmo--;

                    string ammo = GameManager.Instance.gunAmmo.ToString();
                    municion.text = ammo;

                    GameObject newBullet;

                    newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

                    newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);

                    shotRateTime = Time.time + shotRate;

                    Destroy(newBullet, 3);
                }

            }
            
        }
    }
    IEnumerator EsperarYEliminarMensaje(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        mensaje.text = "";
        mensajeMostrado = false;
    }
}
