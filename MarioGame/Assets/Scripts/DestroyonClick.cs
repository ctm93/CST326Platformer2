using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DestroyonClick : MonoBehaviour
{

    [SerializeField] Text coinText;
    public int coinPoints = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                BoxCollider boxCollider = hit.collider as BoxCollider;

                if (boxCollider.tag == "questionbox")
                {
                    Destroy(boxCollider.gameObject);
                    //Debug.Log("destroyed qeustionbox");
                    coinPoints = coinPoints + 100;
                    coinText.text = coinPoints.ToString("000"); ;
                }

                if(boxCollider.tag == "brick")
                {
                    //Debug.Log("destroyed brick");
                    Destroy(boxCollider.gameObject);
                }

            }
        }
    }
}