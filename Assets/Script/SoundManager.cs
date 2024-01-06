using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    private AudioSource _sfxAudioSource;
    private AudioSource _bgmAudioSource;

    public static SoundManager Instance
    {
        get
        {
            if (_instance != null)
            {
                return _instance;
            }

            GameObject g = new GameObject("SoundManager");
            _instance = g.AddComponent<SoundManager>();
            _instance._sfxAudioSource = g.AddComponent<AudioSource>();
            _instance._bgmAudioSource = g.AddComponent<AudioSource>();
            _instance._bgmAudioSource.loop = true;
            DontDestroyOnLoad(g);
            return _instance;
        }
    }

    public void Play(AudioClip clip)
    {
        _sfxAudioSource.PlayOneShot(clip);
    }

    public void SetBgm(AudioClip bgm)
    {
        StopBgm();
        _bgmAudioSource.clip = bgm;
        _bgmAudioSource.Play();
    }

    public void StopBgm()
    {
        _bgmAudioSource.Stop();
    }
}
