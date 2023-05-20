using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Raycast : MonoBehaviour
{

    [SerializeField] private Camera m_CameraTwo;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = m_CameraTwo.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 2f);
            if(Physics.Raycast(ray, out hit))
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
