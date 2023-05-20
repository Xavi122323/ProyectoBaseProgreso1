using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pausa();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "EntradaParlamento")
        {
            SceneManager.LoadScene(2);
        }else if(other.tag == "SalidaParlamento")
        {
            SceneManager.LoadScene(1);
        }
    }

    private void pausa()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadSceneAsync(0);
        }
    }
}
