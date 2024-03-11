using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioSource _sfx;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void PlayMusic(AudioClip clip)
    {
        _music.clip = clip;
        _music.Play();
    }
    
    public void PlaySFX(AudioClip clip, Vector3 worldPosition)
    {
        _sfx.transform.position = worldPosition;
        _sfx.PlayOneShot(clip);
    }
}
