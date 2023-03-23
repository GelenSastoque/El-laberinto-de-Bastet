using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoGato : MonoBehaviour
{
    public Vector2 Sensibilidad;
    private Rigidbody cuerpito;
   
    float velocidaad = 3f;

    // Start is called before the first frame update
    void Start()
    {
        cuerpito=GetComponent<Rigidbody>();
        cuerpito.AddForce(1,1,1);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 Velocidad;
        if(horizontal != 0 ||vertical != 0)
        {
            Velocidad = (transform.forward * vertical + transform.right * horizontal).normalized*velocidaad;
        }
        else
        {
            Velocidad = Vector3.zero;
        }
        if (horizontal != 0)
        {
            transform.Rotate(Vector3.up * horizontal * Sensibilidad.x);
        }
        
        cuerpito.velocity = Velocidad;
    }
}
