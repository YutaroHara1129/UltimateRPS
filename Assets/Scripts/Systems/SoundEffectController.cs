using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectController : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _audioClipList = new List<AudioClip>();
    [SerializeField] private AudioSource _audioSource;

    public void PlayAudioOneShot(int index)
    {
        _audioSource.pitch = 1.0f;
        _audioSource.PlayOneShot(_audioClipList[index]);
    }
    public void PlayAudioOneShot_RandomPitch(int index, float range)
    {
        range = Mathf.Abs(range);
        _audioSource.pitch = 1.0f + Random.Range(-range, range);
        _audioSource.PlayOneShot(_audioClipList[index]);
    }
}
