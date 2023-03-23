using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    CharacterController characterController;

    [Header("Opciones de Presonaje")]
    public float walkSpeed = 6.0f;
    public float runSpeed = 10.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    [Header("Opciones de Camara")]
    public Camera cam;
    public float mouseHorizontal = 3.0f;
    public float mouseVertical = 2.0f;
    public float minRotation = -65.0f;
    public float maxRotation = 60.0f;
    float h_mouse, v_mouse;

    float velocidad = 2f;
    float velocidadRotacion =450f;

    private Vector3 move = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

        //characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        h_mouse += mouseHorizontal * Input.GetAxis("Mouse X");
        v_mouse += mouseVertical * Input.GetAxis("Mouse Y");

        cam.transform.localEulerAngles = new Vector3(0, h_mouse, 0);
        transform.localEulerAngles = new Vector3(0, h_mouse, 0);

        v_mouse = Mathf.Clamp(v_mouse, minRotation, maxRotation);
        cam.transform.localEulerAngles = new Vector3(-v_mouse, 0, 0);

        //if (characterController.isGrounded)
        //{
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            Vector3 Direccion = new Vector3(horizontal, 0, vertical);
            Direccion.Normalize();

            transform.Translate(Direccion * velocidad * Time.deltaTime, Space.World);

            if (Direccion != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(Direccion, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, velocidadRotacion * Time.deltaTime);
            }
            //move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            //if (Input.GetKey(KeyCode.LeftShift))
            //    move = transform.TransformDirection(move) * runSpeed;
            //else
            //    move = transform.TransformDirection(move) * walkSpeed;

            //if (Input.GetKey(KeyCode.Space))
            //    move.y = jumpSpeed;
        //}
        //move.y -= gravity * Time.deltaTime;
        //characterController.Move(move * Time.deltaTime);
    }
}
