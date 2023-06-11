using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemigoEsqueleto : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;

    public Slider barraVidaEnemigo;
    public int vidas = 3;

    public GameObject target;
    public bool atacando;
    public bool muerto = false;

    public AudioSource audioCorrer;

    //variables del spawn de munición de enemigos
    public GameObject specialAmmo;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
        //audioPasos = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        Comportamiento_Enemigo();

    }

    public void Comportamiento_Enemigo()
    {
        if (muerto == false)
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 10 || GameManager.Instance.sinVidas == true)
            {

                ani.SetBool("run", false);
                cronometro += 1 * Time.deltaTime;
                if (cronometro >= 4)
                {
                    rutina = Random.Range(0, 2);
                    cronometro = 0;
                }
                switch (rutina)
                {
                    case 0:
                        ani.SetBool("walk", false);
                        //print("Idle");
                        break;
                    case 1:
                        grado = Random.Range(0, 360);
                        angulo = Quaternion.Euler(0, grado, 0);
                        rutina++;
                        break;
                    case 2:
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                        transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                        ani.SetBool("walk", true);
                        //print("Comportamiento normal");
                        break;
                }
            }
            else
            {
                if (Vector3.Distance(transform.position, target.transform.position) > 1 && !atacando && GameManager.Instance.sinVidas == false)
                {
                    //Debug.Log(GameManager.Instance.sinVidas.ToString());
                    var lookPos = target.transform.position - transform.position;
                    lookPos.y = 0;
                    var rotation = Quaternion.LookRotation(lookPos);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                    ani.SetBool("walk", false);
                    ani.SetBool("run", true);
                    transform.Translate(Vector3.forward * 3 * Time.deltaTime);
                    if (!audioCorrer.isPlaying)
                    {
                        audioCorrer.Play();
                    }
                    ani.SetBool("attack", false);
                }else
                {
                    if (GameManager.Instance.sinVidas == false) { 
                        audioCorrer.Stop();
                        ani.SetBool("walk", false);
                        ani.SetBool("run", false);

                        ani.SetBool("attack", true);
                        atacando = true;
                    }
                }
                
            }
        }

    }

    public void Final_Ani()
    {
        ani.SetBool("attack", false);
        atacando = false;
        ani.SetBool("attack", false);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Bala"))
        {
            vidas--;
            barraVidaEnemigo.value = vidas;

            if (vidas <= 0)
            {
                ani.SetBool("walk", false);
                ani.SetBool("run", false);

                ani.SetBool("attack", false);
                ani.SetTrigger("Death");
                muerto = true;
                //creaci�n de la munici�n especial
                GameObject newBullet;

                newBullet = Instantiate(specialAmmo, spawnPoint.position, spawnPoint.rotation);
                GameManager.Instance.enemigosEliminados += 1;
                //Debug.Log("Eenemigos Eliminados" + GameManager.Instance.enemigosEliminados.ToString());
                Destroy(gameObject, 2);
            }

        }else if (other.gameObject.CompareTag("ShotgunAmmo"))
        {
            vidas--;
            vidas--;
            barraVidaEnemigo.value = vidas;
            if (vidas <= 0)
            {
                ani.SetBool("walk", false);
                ani.SetBool("run", false);

                ani.SetBool("attack", false);
                ani.SetTrigger("Death");
                muerto = true;
                //creaci�n de la munici�n especial
                GameObject newBullet;

                newBullet = Instantiate(specialAmmo, spawnPoint.position, spawnPoint.rotation);
                GameManager.Instance.enemigosEliminados+=1;
                //Debug.Log("Eenemigos Eliminados" + GameManager.Instance.enemigosEliminados.ToString());
                Destroy(gameObject, 2);
            }
        }
    }
}