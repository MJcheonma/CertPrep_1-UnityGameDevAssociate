using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenuController : MonoBehaviour
{
    public AudioMixer audiomixer;
    //public Slider volumeSlider;

    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;

    public TMP_Dropdown qualityDropdown;

    private void Start()
    {
        //volumeSlider.value = AudioListener.volume;

        ResolutionSetting();

        QualitySetting();
    }

    void ResolutionSetting()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    void QualitySetting()
    {
        // Clear the dropdown options
        qualityDropdown.ClearOptions();

        // Get the names of all available quality levels
        string[] qualityLevels = QualitySettings.names;

        // Create a list to hold the options for the dropdown
        List<TMP_Dropdown.OptionData> dropdownOptions = new List<TMP_Dropdown.OptionData>();

        // Add each quality level name to the dropdown options
        foreach (string level in qualityLevels)
        {
            dropdownOptions.Add(new TMP_Dropdown.OptionData(level));
        }

        // Assign the options to the dropdown
        qualityDropdown.options = dropdownOptions;

        // Find the current quality level index
        int currentQualityLevel = QualitySettings.GetQualityLevel();

        // Set the dropdown value to match the current quality level
        qualityDropdown.value = currentQualityLevel;
    }

    public void SetVolume(float volume)
    {
        audiomixer.SetFloat("volume", volume);
        //AudioListener.volume = volume;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
