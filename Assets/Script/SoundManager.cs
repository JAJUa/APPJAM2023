using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    private AudioSource _audioSource;

    public static SoundManager Instance
    {
        get
        {
            if (_instance != null)
            {
                return _instance;
            }

            GameObject g = new GameObject("SoundManager");
            g.AddComponent<AudioSource>();
            _instance = g.AddComponent<SoundManager>();
            return _instance;
        }
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Play(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }
}
