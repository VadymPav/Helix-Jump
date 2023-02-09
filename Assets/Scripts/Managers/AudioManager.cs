using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public static AudioManager instance;

	public List<Sound> sounds;

	public void Init ()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		} else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}

	public void Play (string sound)
	{
		if(GameManager.mute) return;
		Sound s = sounds.Find(item => item.name == sound);
		s.source.Play();
	}

}
