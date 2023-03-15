using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class controladorjuego : MonoBehaviour
{
  public static controladorjuego Instance;
  [SerializeField] private GameObject[] puntosDeControl;
  [SerializeField] private GameObject juagador;
  private int indexPuntosControl;

  public TextMeshProUGUI puntos;
  private void Awake()
   {
    Instance = this;
    puntosDeControl = GameObject.FindGameObjectsWithTag("PuntoDeControl");
    indexPuntosControl = PlayerPrefs.GetInt("puntosIndex");
    //Instantiate(juagador, puntosDeControl[indexPuntosControl].transform.position, Quaternion.identity);
  }
  //metodo para cambiar la POSICION DONDE APARECE EL JUGADOR;
  public void UltimoPuntoControl(GameObject puntoControl){
    for(int i=0; 1<puntosDeControl.Length;i++){

        if(puntosDeControl[i]==puntoControl){
            PlayerPrefs.SetInt("puntosIndex",i);
        }
         puntos.text= PlayerPrefs.GetInt("puntosIndex").ToString();
    }
  }
  private void Update() {
    if(Input.GetKeyDown(KeyCode.R)){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  }
}
