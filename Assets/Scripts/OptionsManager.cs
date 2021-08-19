using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OptionsManager : MonoBehaviour
{
	public Slider volumeSlider, diffSlider;


	public AudioManager audioManager;

	// Use this for initialization
	void Start()
	{
		print(PlayerPrefsManager.GetMasterVolume());
		audioManager = GameObject.FindObjectOfType<AudioManager>();
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		diffSlider.value = PlayerPrefsManager.GetDifficulty();
	}

	// Update is called once per frame
	void Update()
	{
		audioManager.SetVolume("Background", volumeSlider.value);
	}

	public void SaveAndExit()
	{
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		PlayerPrefsManager.SetDifficulty(diffSlider.value);

	}

	public void SetDefaults()
	{
		volumeSlider.value = 0.8f;
		diffSlider.value = 2f;
	}
}

