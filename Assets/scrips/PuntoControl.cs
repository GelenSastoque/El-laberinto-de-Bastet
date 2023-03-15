using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class PuntoControl : MonoBehaviour
{
    //Para cuando se quiere animar
    //private Animator animator;
    public  TextMeshProUGUI Puntos;
    private int contador = 0;
     private void Start() {
       // animator= GetComponent<Animator>{};
    }
    private void OnTriggerEnter(Collider other) {
       if((other.CompareTag("Player")) ) {
         Debug.Log("Pasa1");
         //for(int i=0;1<contador;i++){
            contador= contador + 1;
            Puntos.text = contador.ToString();
           //  puntos.text= (Get.contador+1).ToString();
        // }
        
         // Destroy(other.gameObject);
        } 
        

        if (other.CompareTag("Player2") )
        {
            Debug.Log(contador);
         //   puntos.text= (contador+1).ToString();
           // Destroy(other.gameObject);
           // SceneManager.LoadScene(0);
          // animator.SetTrigger("Activar");
          //controladorjuego.Instance.UltimoPuntoControl(gameObject);
           contador= contador + 1;
            Puntos.text = contador.ToString();
        }
        Debug.Log("Que Pasa");
        
    }
}
