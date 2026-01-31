using System.Collections.Generic;
using UnityEngine;


public class AudioBase : MonoBehaviour
{
    [SerializeField] protected List<AudioClip> audioClips;
    [SerializeField] protected AudioSource audioSource;

    private void Awake()
    {
        audioSource.playOnAwake = false;
    }

    public void PlaySound(int index)
    {
        if (index >= audioClips.Count || index < 0) return;
        audioSource.PlayOneShot(audioClips[index]);
    }
}
