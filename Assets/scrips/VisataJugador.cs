using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisataJugador : MonoBehaviour
{
    public GameObject jugador;
    public int xcamera;
    public int ycamera;
    public int zcamera;

    public float speedm;
    public float speedv;
    float yaw;
    float pitch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position= jugador.transform.position + new Vector3(xcamera, 1/2 ,zcamera);
        //transform.position= jugador.transform.position + new Vector3(xcamera, 5 ,-3);
       // yaw += speedm * Input.GetAxis("Mouse X");
      ///  pitch -= speedv * Input.GetAxis("Mouse Y");
         yaw += 2 * Input.GetAxis("Mouse X");
        pitch -= 2 * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        
    }
}
