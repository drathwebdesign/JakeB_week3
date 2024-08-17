using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance; // Singleton instance

    public TextMeshProUGUI timeSurvivedText;
    public Volume postProcessVolume;
    public GameObject gameOverCanvas;
    public TextMeshProUGUI gameOverTimeText;
    public TextMeshProUGUI finalScoreText;

    private Vignette vignette;
    private float timeSurvived = 0f;
    private float vignetteIntensityMax = 1f;
    private float vignetteIntensityMin = 0.1f;
    private float timeToMaxVignette = 240f;
    private bool isGameOver = false;
    private ScoreManager scoreManager;

    void Awake() {
        // Set up the singleton instance
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }

        // Get the ScoreManager reference
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Start() {
        UpdateTimeUI();

        if (postProcessVolume.profile.TryGet(out vignette)) {
            vignette.intensity.value = vignetteIntensityMin;
        }

        gameOverCanvas.SetActive(false);
    }

    void Update() {
        if (isGameOver) return;

        timeSurvived += Time.deltaTime;
        UpdateTimeUI();
        UpdateVignetteIntensity();
    }

    private void UpdateTimeUI() {
        timeSurvivedText.text = "Time Survived: " + FormatTime(timeSurvived);
    }

    private void UpdateVignetteIntensity() {
        float t = Mathf.Clamp01(timeSurvived / timeToMaxVignette);
        vignette.intensity.value = Mathf.Lerp(vignetteIntensityMin, vignetteIntensityMax, t);
    }

    private string FormatTime(float time) {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time % 60F);
        return string.Format("{0:0}:{1:00}", minutes, seconds);
    }

    public void PlayerDied() {
        isGameOver = true;
        gameOverCanvas.SetActive(true);

        if (scoreManager != null) {
            finalScoreText.text = "Spiders Killed: " + scoreManager.GetScore().ToString();
        }
        gameOverTimeText.text = "Time Survived: " + FormatTime(timeSurvived);
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
