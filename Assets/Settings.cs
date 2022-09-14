using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
   public Dropdown _resolutionDropdown;

   Resolution[] _resolutions;

   private void Start() 
   {
    _resolutionDropdown.ClearOptions();
    List<string> options = new List<string>();
    _resolutions = Screen.resolutions;
    int _currentResolutionIndex = 0;

    for (int i = 0; i < _resolutions.Length; i++)
    {
        string option = _resolutions[i].width + "x" + _resolutions[i].height + " " + _resolutions[i].refreshRate + "Hz";
        options.Add(option);    

        if (_resolutions[i].width == Screen.currentResolution.width && _resolutions[i].height == Screen.currentResolution.height)
        _currentResolutionIndex = i;
    }

    _resolutionDropdown.AddOptions(options);
    _resolutionDropdown.RefreshShownValue();
    LoadSettings(_currentResolutionIndex);
   }

   public void SetFullscreen(bool isFullScreen)
   {
    Screen.fullScreen = isFullScreen;
    SaveSettings();
   }

   public void SetResolution(int resolutionIndex)
   {
    Resolution resolution = _resolutions[resolutionIndex];
    

    SaveSettings();
   }

   public void SaveSettings()
   {
    PlayerPrefs.SetInt("ResolutionPreference", _resolutionDropdown.value);
    PlayerPrefs.SetInt("FullScreenPreference", System.Convert.ToInt32(Screen.fullScreen));
   }

   public void LoadSettings(int currentResolutionIndex)
   {
    if (PlayerPrefs.HasKey("ResolutionPreference"))
    _resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
    else
    _resolutionDropdown.value = currentResolutionIndex;

    if(PlayerPrefs.HasKey("FullScreenPreference"))
    Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullScreenPreference"));
    else
    Screen.fullScreen = true;
   }

   
}
