using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class CargoCounter : MonoBehaviour
{
    int CargoCount;
    public int MaxCargo;
    public TextMeshProUGUI CargoText;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Cargo"))
        {
            CargoCount += 1;
            CargoUpdate();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cargo"))
        {
            CargoCount -= 1;
            CargoUpdate();
        }
    }

    void CargoUpdate()
    {
        CargoText.text = "Cargo: " + CargoCount + "/" + MaxCargo;
    }

}
