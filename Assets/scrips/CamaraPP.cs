using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPP : MonoBehaviour
{
    private new Transform camera;
    public Vector2 Sensibilidad;

    // Start is called before the first frame update
    void Start()
    {
        camera = transform.Find("Camera");
    }

    // Update is called once per frame
    void Update()
    {
        //float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxis("Mouse Y");

        //if(horizontal != 0)
        //{
        //    transform.Rotate(Vector3.up * horizontal * Sensibilidad.x);
        //}
        if(vertical !=0)
        {
            float angulo = (camera.localEulerAngles.x - vertical * Sensibilidad.y+360)%360;
            if (angulo >180)
            {
                angulo -= 360;

            }
            angulo = Mathf.Clamp(angulo, -80, 80);
            camera.localEulerAngles = Vector3.right * angulo;
        }
     
    }
}
