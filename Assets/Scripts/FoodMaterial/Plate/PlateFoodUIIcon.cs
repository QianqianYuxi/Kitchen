using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlateFoodUIIcon : MonoBehaviour//ÿ��ͼ���������
{

    [SerializeField] private Image iconImage;

    public void Show(Sprite sprite)
    {
        gameObject.SetActive(true);
        iconImage.sprite = sprite;//���þ���ͼ
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
