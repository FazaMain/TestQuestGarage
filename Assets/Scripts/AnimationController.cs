using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AnimationController : MonoBehaviour
{
    public Animator GarageAnimator;
    public Animator TextAnimator;
    public AudioSource GarageSound;

    private void Start()
    {
        StartCoroutine(StartAnimCo());
    }


    IEnumerator StartAnimCo()
    {
        yield return null;
        yield return new WaitForSeconds(1f);
        GarageSound.Play();
        GarageAnimator.SetTrigger("Act");
        yield return new WaitForSeconds(2.2f);
        TextAnimator.SetTrigger("Act");
    }
}
