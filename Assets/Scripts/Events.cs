using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public GameObject interactCanvas;
    public GameObject dialogCanvas;
    public GameObject dialogManager;

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cin"))
        {
            interactCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Cin"))
        {
            interactCanvas.SetActive(false);
            dialogCanvas.SetActive(false);
            dialogManager.GetComponent<Dialog>().ResetDialog();
        }
    }

    private void Update()
    {
        if (interactCanvas!=null && interactCanvas.activeInHierarchy) 
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogCanvas.SetActive(true);
                interactCanvas.SetActive(false);
            }
        }
    }
}
