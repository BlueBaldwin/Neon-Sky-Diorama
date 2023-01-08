using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparksNoise : MonoBehaviour
{
	private ParticleSystem _particleSystem;
	[SerializeField] AudioClip Clip;
	private bool _play;
	
    void Start()
    {
	    _particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
	    if (_particleSystem.particleCount > 0)
	    {
		   SoundManager.Instance.PlaySparkSFX(Clip);
	    }
	    else
	    {
		    SoundManager.Instance.StopSFX(Clip);
	    }
    }
}
