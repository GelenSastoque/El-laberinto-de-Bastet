using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInter : MonoBehaviour
{
    // private Tag PlayerTag;
    [SerializeField]
    private LayerMask pickableLayerMask; //detect all the collider that are pickable
    [SerializeField]
    private Transform playerCameraTransform; //get the forward 
    // [SerializeField]
    // private GameObject pickUpUI; 

    [SerializeField]
    [Min(1)]
    private float hitRange=2; 
    private RaycastHit hit;

    [SerializeField]
    private Transform BocaParent;
    [SerializeField]
    private GameObject ItemBoca;

    [SerializeField]
    private InputActionReference interactioninput, dropinput, useinput;
    // Start is called before the first frame update
    void Start()
    {
        interactioninput.action.performed += Interactuar;
        dropinput.action.performed += Soltar;
        useinput.action.performed += Transportando;
    }
    private void Transportando(InputAction.CallbackContext obj)
    {

    }
    private void Soltar(InputAction.CallbackContext obj)
    {
        if (ItemBoca != null)
        {
            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
            
            ItemBoca.transform.SetParent(null);
            ItemBoca = null;
            if (rb != null)
            {
                rb.isKinematic = false;
                
            }
            ItemBoca.transform.localScale = new Vector3(2f, 2f, 2f);
        }
    }
    private void Interactuar(InputAction.CallbackContext obj)
    {
        Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
        if(hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            ItemBoca = hit.collider.gameObject;
            ItemBoca.transform.position = Vector3.zero;
            ItemBoca.transform.rotation = Quaternion.identity;
            ItemBoca.transform.localScale = new Vector3(1f,1f,1f);
            ItemBoca.transform.SetParent(BocaParent.transform, false);
            if(rb != null)
            {
                rb.isKinematic = true;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward*hitRange,Color.red);
        if(hit.collider!=null){ //already selected something
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(false); //?. check if  this is collider actually has the getcomponent
            // pickUpUI.SetActive(false);
        }
        if(ItemBoca != null)
        {
            return;
        }

        if(Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, pickableLayerMask)){
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
            // pickUpUI.SetActive(true);
            //Debug.Log("Objeto encontrado");
        }

    }
}
