using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VillagerManager : MonoBehaviour
{
    bool playerDetection = false;
    public GameObject template;
    public GameObject canva;

    void Start()
    {
        
    }

    void Update()
    {
        if(playerDetection && !FirstPersonMovement.dialog && Input.GetKeyDown(KeyCode.E))
        {
            canva.SetActive(true);
            FirstPersonMovement.dialog = true;
            newDialog("Hola, el cambio climatico es preocupante estas de acuerdo");
            newDialog("Interesante");
            newDialog("Adios");
            canva.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    void newDialog(string text)
    {
        GameObject templateClone = Instantiate(template, template.transform);
        templateClone.transform.parent = canva.transform;
        templateClone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag=="Doctor" || other.tag=="Zombie" || other.tag=="Soccer" || other.tag=="Knight")
        {
            playerDetection = true;
            Destroy(other,5f);
        }
    }

    public void favor()
    {
        GameEventsManager.instance.aumentarCap();
    }

    public void contra()
    {
        GameEventsManager.instance.disminuirCap();
    }


    
}
