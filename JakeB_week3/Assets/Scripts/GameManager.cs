using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour {
    public TextMeshProUGUI timeSurvivedText; // Reference to the TextMeshProUGUI component
    public Volume postProcessVolume; // Reference to the Volume for post-processing

    private Vignette vignette;
    private float timeSurvived = 0f; // Time the player has survived
    private float vignetteIntensityMax = 1f; // The maximum vignette intensity you want to reach
    private float vignetteIntensityMin = 0.1f; // The minimum vignette intensity (initial value)
    private float timeToMaxVignette = 120f; // Time (in seconds) to reach max vignette intensity

    void Start() {
        // Initialize the UI with 0 time
        UpdateTimeUI();

        // Access the Vignette effect in the Volume Profile
        if (postProcessVolume.profile.TryGet(out vignette)) {
            vignette.intensity.value = vignetteIntensityMin;
        }
    }

    void Update() {
        timeSurvived += Time.deltaTime;
        UpdateTimeUI();
        UpdateVignetteIntensity();
    }

    private void UpdateTimeUI() {
            // Format the time to show minutes and seconds
            timeSurvivedText.text = "Time Survived: " + FormatTime(timeSurvived);
    }

    private void UpdateVignetteIntensity() {
            // Calculate the current vignette intensity based on time survived
            float t = Mathf.Clamp01(timeSurvived / timeToMaxVignette);
            vignette.intensity.value = Mathf.Lerp(vignetteIntensityMin, vignetteIntensityMax, t);
    }

    private string FormatTime(float time) {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time % 60F);
        return string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}