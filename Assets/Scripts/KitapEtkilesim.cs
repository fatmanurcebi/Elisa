using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KitapEtkilesim : MonoBehaviour
{
    public GameObject canvas;

    [SerializeField] private Camera cam;
    

    void Start()
    {
       cam = Camera.main;
    }
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {

                if (hit.collider.gameObject.tag == "kitap")
                {
                    canvas.SetActive(true);
                }
            }
        }
    }
}
