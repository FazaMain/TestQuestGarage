using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundScript : MonoBehaviour
{

    public AudioSource[] SoundsArray;

    private void OnEnable()
    {
        DragObjectScript.SoundPlay += PlaySound;
    }
    private void OnDisable()
    {
        DragObjectScript.SoundPlay -= PlaySound;
    }
    void PlaySound(int i)
    {
        SoundsArray[i].Play();
    }
    
}
