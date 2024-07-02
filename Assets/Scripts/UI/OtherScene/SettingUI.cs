using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class SettingUI : MonoBehaviour
{
    public static SettingUI Instance { get; private set; }
    [SerializeField] private GameObject uiParent;
    [SerializeField] private Button soundButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button upButton;  
    [SerializeField] private Button downButton;    
    [SerializeField] private Button leftButton;    
    [SerializeField] private Button rightButton;
    [SerializeField] private Button operationButton;
    [SerializeField] private Button interactButton;   
    [SerializeField] private Button pauseButton;
    
    [SerializeField] private TextMeshProUGUI soundButtonText;
    [SerializeField] private TextMeshProUGUI musicButtonText;
    [SerializeField] private TextMeshProUGUI upButtonText;
    [SerializeField] private TextMeshProUGUI downButtonText;
    [SerializeField] private TextMeshProUGUI leftButtonText;
    [SerializeField] private TextMeshProUGUI rightButtonText;
    [SerializeField] private TextMeshProUGUI operationButtonText;
    [SerializeField] private TextMeshProUGUI interactButtonText;
    [SerializeField] private TextMeshProUGUI pauseButtonText;

    [SerializeField] private GameObject reBindingHint;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    private void Start()
    {
        Hide();
        UpdateVolumeVisual();//开始时加载当前音量
        soundButton.onClick.AddListener(() =>
        {
            SoundManager.Instance.ChangeVolume();
            UpdateVolumeVisual();//点击变化加载
        }
        );
        musicButton.onClick.AddListener(() =>
        {
            MusicManager.Instance.ChangeVolume();
            UpdateVolumeVisual();//点击变化加载
        }
        );
        closeButton.onClick.AddListener(() =>
        {
            Hide();
        }
        );
        upButton.onClick.AddListener(()=>{ReBinding(GameInput.BindingType.Up);});
        downButton.onClick.AddListener(() =>{ReBinding(GameInput.BindingType.Down);});
        leftButton.onClick.AddListener(() =>{ReBinding(GameInput.BindingType.Left);});
        rightButton.onClick.AddListener(() =>{ReBinding(GameInput.BindingType.Right);});
        operationButton.onClick.AddListener(() =>{ReBinding(GameInput.BindingType.Operation);});
        interactButton.onClick.AddListener(() =>{ReBinding(GameInput.BindingType.Interact);});
        pauseButton.onClick.AddListener(() =>{ReBinding(GameInput.BindingType.Pause);});
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Show()
    {
        uiParent.SetActive(true);
    }
    public void Hide()
    {
        uiParent.SetActive(false);
    }
    void UpdateVolumeVisual()
    {
        soundButtonText.text = "音效大小：" + SoundManager.Instance.GetVolume();
        musicButtonText.text = "音乐大小：" + MusicManager.Instance.GetVolume();

        upButtonText.text = GameInput.Instance.GetBindingTypeString(GameInput.BindingType.Up);
        downButtonText.text = GameInput.Instance.GetBindingTypeString(GameInput.BindingType.Down);
        leftButtonText.text = GameInput.Instance.GetBindingTypeString(GameInput.BindingType.Left);
        rightButtonText.text = GameInput.Instance.GetBindingTypeString(GameInput.BindingType.Right);
        operationButtonText.text = GameInput.Instance.GetBindingTypeString(GameInput.BindingType.Operation);
        interactButtonText.text = GameInput.Instance.GetBindingTypeString(GameInput.BindingType.Interact);
        pauseButtonText.text = GameInput.Instance.GetBindingTypeString(GameInput.BindingType.Pause);
    }
    private void ReBinding(GameInput.BindingType bindingType)
    {
        reBindingHint.SetActive(true);
        GameInput.Instance.ReBinding(bindingType,()=> {
            UpdateVolumeVisual();
            reBindingHint.SetActive(false);
        }
            );
    }
}
