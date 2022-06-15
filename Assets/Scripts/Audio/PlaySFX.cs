using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySFX : MonoBehaviour
{
    [SerializeField]
    AudioClip[] clips;

    AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();    
    }

    public void PlaySound()
    {
        if (source.isPlaying)
        { return; }

        source.Play();
    }

    public void PlayFirstClip()
    {
        var originalClip = source.clip;
        source.clip = clips[0];
        source.Play();

        if (originalClip)
            source.clip = originalClip;
    }
}
