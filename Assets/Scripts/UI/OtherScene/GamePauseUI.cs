using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField] private GameObject UIParent;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button settingButton;
    // Start is called before the first frame update
    void Start()
    {
        Hide();
        GameManager.Instance.OnGamePaused += GameManager_OnGamePaused;
        GameManager.Instance.OnGameUnPaused += GameManager_OnGameUnPaused;
        resumeButton.onClick.AddListener(() =>
        {
            GameManager.Instance.ToggleGamePause();
        });
        menuButton.onClick.AddListener(() =>
        {
            GameInput.Instance.OnDistory();//释放Input事件和资源
            Loader.Load(Loader.Scene.GameMenu);
        });
        settingButton.onClick.AddListener(() =>
        {
            SettingUI.Instance.Show();
        });
    }

    private void GameManager_OnGameUnPaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void GameManager_OnGamePaused(object sender, System.EventArgs e)
    {
        Show();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Show()
    {
        UIParent.SetActive(true);
    }
    private void Hide()
    {
        UIParent.SetActive(false);
    }
}
