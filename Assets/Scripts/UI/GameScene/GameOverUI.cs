using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject uiParent;
    [SerializeField] private TextMeshProUGUI numberText;

    private void Start()
    {
        GameManager.Instance.OnStateChanged += gameManager_OnStateChanged;
    }

    private void gameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsGameOverState())
        {
            Show();
        }
    }

    private void Show()
    {
        numberText.text = OrderManager.Instance.GetSuccessDeliveryCount().ToString();
        uiParent.gameObject.SetActive(true);
    }
    private void Hide()
    {
        uiParent.gameObject.SetActive(false);
    }
}
