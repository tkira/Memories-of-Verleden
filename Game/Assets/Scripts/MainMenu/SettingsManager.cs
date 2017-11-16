using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SettingsManager : MonoBehaviour {

	public Slider masterVolume;
	public Slider musicVolume;
	public Toggle fullscreenToggle;
	public Dropdown resolutionDropdown;
	public Dropdown vsyncDropdown;
	public Button applyButton;

	public AudioSource audioMusic;
	public AudioSource audioSounds;
	public Resolution[] resolutions;
	public GameSettings gameSettings;
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable(){
		gameSettings = new GameSettings ();
		fullscreenToggle.onValueChanged.AddListener(delegate {OnFullscreenToggle();});
		resolutionDropdown.onValueChanged.AddListener(delegate {OnResolutionChange();});
		vsyncDropdown.onValueChanged.AddListener(delegate {OnVSyncChange();});
		masterVolume.onValueChanged.AddListener(delegate {OnVolumeChange();});
		musicVolume.onValueChanged.AddListener(delegate {OnVolumeMusicChange();});
		applyButton.onClick.AddListener(delegate {OnApplyButton();});

		resolutions = Screen.resolutions;
		foreach(Resolution resolution in resolutions){
			resolutionDropdown.options.Add (new Dropdown.OptionData (resolution.ToString ()));
		}
		LoadSettings ();
	}

	public void OnFullscreenToggle(){
		gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
	}

	public void OnResolutionChange(){
		Screen.SetResolution (resolutions [resolutionDropdown.value].width, resolutions [resolutionDropdown.value].height, Screen.fullScreen);
		gameSettings.resolutionIndex = resolutionDropdown.value;
	}

	public void OnVSyncChange(){
		QualitySettings.vSyncCount = gameSettings.vsync = vsyncDropdown.value;
	}

	public void OnVolumeChange(){
		AudioListener.volume = gameSettings.masterVolume = masterVolume.value;
	}

	public void OnVolumeMusicChange(){
		audioMusic.volume = gameSettings.musicVolume = musicVolume.value;
	}

	public void SaveSettings(){
		string jsonData = JsonUtility.ToJson (gameSettings, true);
		File.WriteAllText (Application.persistentDataPath + "/gameSettings.json", jsonData);

	}

	public void OnApplyButton(){
		SaveSettings ();
	}

	public void LoadSettings(){
		gameSettings = JsonUtility.FromJson<GameSettings> (File.ReadAllText(Application.persistentDataPath + "/gameSettings.json"));
		masterVolume.value = gameSettings.masterVolume;
		musicVolume.value = gameSettings.musicVolume;
		vsyncDropdown.value = gameSettings.vsync;
		resolutionDropdown.value = gameSettings.resolutionIndex;
		fullscreenToggle.isOn = gameSettings.fullscreen;
	}
		
	public void Awake(){
		gameSettings = JsonUtility.FromJson<GameSettings> (File.ReadAllText(Application.persistentDataPath + "/gameSettings.json"));
		masterVolume.value = gameSettings.masterVolume;
		musicVolume.value = gameSettings.musicVolume;
		vsyncDropdown.value = gameSettings.vsync;
		resolutionDropdown.value = gameSettings.resolutionIndex;
		fullscreenToggle.isOn = gameSettings.fullscreen;
	}
}
