using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource _MusicSource, _SFXSource;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySparkSFX(AudioClip SFX)
    {
        if (!_SFXSource.isPlaying)
        {
             _SFXSource.PlayOneShot(SFX);
        }
    }

    public void StopSFX(AudioClip SFX)
    {
        _SFXSource.Stop();
    }
}
