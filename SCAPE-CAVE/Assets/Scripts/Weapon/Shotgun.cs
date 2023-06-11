using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shotgun : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bullet;

    public float shotForce = 700f;
    public float shotRate = 0.5f;

    private float shotRateTime = 0;

    public TMP_Text municion;
    public TMP_Text cargador;

    public AudioSource SoundShot;
    public AudioClip Shot;

    public TMP_Text mensaje;
    private bool mensajeMostrado = false;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (GameManager.Instance.shotgunReload == false)
            {
                if (GameManager.Instance.shotgunAmmo == 0 && GameManager.Instance.shotgunAmmoCargador == 0)
                {
                    mensaje.text = "No hay munición";
                    StartCoroutine(EsperarYEliminarMensaje(2f));
                }
                else if (GameManager.Instance.shotgunAmmo == 0 && GameManager.Instance.shotgunAmmoCargador > 0)
                {
                    mensaje.text = "Debes recargar munición";
                    StartCoroutine(EsperarYEliminarMensaje(2f));
                }
                else
                {
                    if (Time.time > shotRateTime && GameManager.Instance.shotgunAmmo > 0)
                    {
                        GameManager.Instance.shotgunAmmo--;
                        string ammo = GameManager.Instance.shotgunAmmo.ToString();
                        municion.text = ammo;
                        GameObject newBullet;
                        newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
                        newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);
                        shotRateTime = Time.time + shotRate;
                        Destroy(newBullet, 0.25f);
                        SoundShot.PlayOneShot(Shot);
                    }
                }
            }
            else
            {
                mensaje.text = "No puedes disparar mientras recargas";
                StartCoroutine(EsperarYEliminarMensaje(0.5f));
            }
        }
    }

    IEnumerator EsperarYEliminarMensaje(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        mensaje.text = "";
    }
}
