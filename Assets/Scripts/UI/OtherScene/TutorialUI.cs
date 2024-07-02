using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private GameObject uiParent;
    [SerializeField] private TextMeshProUGUI upKeyText;
    [SerializeField] private TextMeshProUGUI downKeyText;
    [SerializeField] private TextMeshProUGUI leftKeyText;
    [SerializeField] private TextMeshProUGUI rightKeyText;
    [SerializeField] private TextMeshProUGUI operationKeyText;
    [SerializeField] private TextMeshProUGUI interactKeyText;
    [SerializeField] private TextMeshProUGUI pauseKeyText;

    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
        Show();
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsWaitingToStartState())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Show()
    {
        UpdateVisual();
        uiParent.SetActive(true);
    }
    private void Hide()
    {
        uiParent.SetActive(false);
    }
    private void UpdateVisual()
    {
        upKeyText.text = GameInput.Instance.GetBindingTypeString(GameInput.BindingType.Up);
        downKeyText.text = GameInput.Instance.GetBindingTypeString(GameInput.BindingType.Down);
        leftKeyText.text = GameInput.Instance.GetBindingTypeString(GameInput.BindingType.Left);
        rightKeyText.text = GameInput.Instance.GetBindingTypeString(GameInput.BindingType.Right);
        operationKeyText.text = GameInput.Instance.GetBindingTypeString(GameInput.BindingType.Operation);
        interactKeyText.text = GameInput.Instance.GetBindingTypeString(GameInput.BindingType.Interact);
        pauseKeyText.text = GameInput.Instance.GetBindingTypeString(GameInput.BindingType.Pause);
    }
}
