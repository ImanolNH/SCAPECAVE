using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;

    public float speed = 5f;
    private float gravity = -15f;
    public float maxDistance = 0.2f;

    public Transform groundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundMask;
    public AudioSource pasos;
    public AudioClip jumpSound;

    bool isGrounded;
    bool isJumping;

    Vector3 velocity;

    public TMP_Text vidasTexto;

    public float jumpHeight = 1;


    // Update is called once per frame
    void Update()
    {
        string vidas = GameManager.Instance.vidas.ToString();
        vidasTexto.text = vidas;

        //Detectar si el "player" esta con los pies en la tierra
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, maxDistance))
        {
            isGrounded = false;
        }
        else
        {
            isGrounded = true;
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Establecemos movimientos a las variables
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            pasos.PlayOneShot(jumpSound);
        }

        characterController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

        if (!isJumping && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 || !isGrounded))
        {
            if (!pasos.isPlaying)
            {
                pasos.Play();
            }
        }
        else
        {
            pasos.Stop();
        }

        if (isGrounded)
        {
            isJumping = false;
        }
    }
}
