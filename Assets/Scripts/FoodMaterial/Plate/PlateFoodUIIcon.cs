using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlateFoodUIIcon : MonoBehaviour//每个图标物体对象
{

    [SerializeField] private Image iconImage;

    public void Show(Sprite sprite)
    {
        gameObject.SetActive(true);
        iconImage.sprite = sprite;//设置精灵图
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
