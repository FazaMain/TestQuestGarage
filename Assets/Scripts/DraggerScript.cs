using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DraggerScript : MonoBehaviour
{
    public static event Action LMBDown;
    public static event Action LMBUP;
    public GameObject DraggerObj;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            LMBDown?.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            LMBUP?.Invoke();
        }
        
    }
    private void FixedUpdate()
    {
        DraggerObj.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
    }
}
