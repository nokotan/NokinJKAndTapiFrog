using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DebuggerControl : MonoBehaviour
{
    public void UnloadScene()
    {
        SceneManager.UnloadSceneAsync(gameObject.scene);
    }

    [SerializeField] Button SwitchSceneButton;

    public void SwitchScene(int sceneID)
    {
        if (sceneID <= 0)
        {
            return;
        }

        SceneManager.LoadScene(sceneID - 1);
    }

    public void ResetClearData()
    {
        ClearCountManager.Instance.ResetClearData();
    }

    public void ResetDeathData()
    {
        FrogDeathRecorder.Instance.ResetDeathData();
    }

    [Header("Initial Zanki")]
    [SerializeField] Slider InitialZankiSlider;
    [SerializeField] Text InitialZankiSliderText;

    public void OnUpdateInitialZankiSlider(float val)
    {
        var newInitialZanki = (int)InitialZankiSlider.value;
        ConfigSystem.Instance.GameSetting.InitialZanki = newInitialZanki;
        InitialZankiSliderText.text = newInitialZanki.ToString();
    }

    [Header("Time Limit")]
    [SerializeField] Slider TimeLimitSlider;
    [SerializeField] Text TimeLimitSliderText;

    public void OnUpdateTimeLimitSlider(float val)
    {
        var newTimeLimit = (int)TimeLimitSlider.value * 5 + 5;
        ConfigSystem.Instance.GameSetting.TimeLimit = newTimeLimit;
        TimeLimitSliderText.text = newTimeLimit.ToString();
    }

    [Header("Debug Text")]
    [SerializeField] Text DebugText;

    void LogReceived(string condition, string stackTrace, LogType type)
    {
        DebugText.text = condition;
    }

    public void OnEnable()
    {
        SwitchSceneButton.Select();

        InitialZankiSlider.onValueChanged.AddListener(OnUpdateInitialZankiSlider);
        InitialZankiSlider.value = ConfigSystem.Instance.GameSetting.InitialZanki;

        TimeLimitSlider.onValueChanged.AddListener(OnUpdateTimeLimitSlider);
        TimeLimitSlider.value = ConfigSystem.Instance.GameSetting.TimeLimit / 5 - 1;

        Time.timeScale = 0.0f;
        Application.logMessageReceived += LogReceived;
    }

    public void OnDisable()
    {
        Time.timeScale = 1.0f;
        Application.logMessageReceived -= LogReceived;
    }
}
