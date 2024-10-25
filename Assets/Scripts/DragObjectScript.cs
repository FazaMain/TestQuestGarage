using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DragObjectScript : MonoBehaviour
{
    public int SoundType;
    public static event Action<int> SoundPlay;
    float Bigscale = 1.1f;

    bool Dragging;
    bool MouseInPosition;

    private void OnEnable()
    {
        DraggerScript.LMBDown += DragStart;
        DraggerScript.LMBUP += DragStop;
    }
    private void OnDisable()
    {
        DraggerScript.LMBDown -= DragStart;
        DraggerScript.LMBUP -= DragStop;
    }

    void DragStart()
    {
        
        if (MouseInPosition)
        {
            transform.localScale = new Vector3(Bigscale, Bigscale, 0);
            SoundPlay?.Invoke(SoundType);
            Dragging = true;
            StartCoroutine(DragCo());
        }
    }
    void DragStop()
    {
        Dragging = false;
        transform.localScale = new Vector3(1, 1, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dragger"))
        {
            MouseInPosition = true;
            Debug.Log("вижу Dragger");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dragger"))
        {
            Debug.Log("Не вижу Dragger");
            MouseInPosition = false;
        }
    }



    IEnumerator DragCo()
    {
        yield return null;
        while (Dragging)
        {
            PosUpdate();
            yield return new WaitForFixedUpdate();
        }
    }
    void PosUpdate()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
    }

}
