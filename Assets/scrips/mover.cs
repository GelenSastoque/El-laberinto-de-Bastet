using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{
 
        public float speed = 2f;

    public float speedm;
    public float speedv;
    float yaw;
    float pitch;

    void FixedUpdate() { 

        yaw += 2 * Input.GetAxis("Mouse X");
        pitch -= 2 * Input.GetAxis("Mouse Y");
       // transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);



if (Input.GetKey(KeyCode.W))

    GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.forward * speed * Time.deltaTime);
else if (Input.GetKey(KeyCode.S))
    GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.back * speed * Time.deltaTime);
else if (Input.GetKey(KeyCode.A))
    GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.left * speed * Time.deltaTime);
else if (Input.GetKey(KeyCode.D))
    GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.right * speed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.Q))
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.up * speed * Time.deltaTime);

  
    }
           
}


