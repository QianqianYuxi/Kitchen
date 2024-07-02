using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image progeressImage;//½ø¶ÈÌõ
    // Start is called before the first frame update
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void SetProgress(float progress)
    {
        Show();
        progeressImage.fillAmount = progress;
    }
}
