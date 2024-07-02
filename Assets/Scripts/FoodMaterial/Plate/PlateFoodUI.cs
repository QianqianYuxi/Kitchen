using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateFoodUI : MonoBehaviour
{
    [SerializeField]private PlateFoodUIIcon foodIcon;
    private void Start()
    {
       foodIcon.Hide();
    }
    public void ShowPlateFoodUI(FoodMaterialSO foodMaterialSO)
    {
        gameObject.SetActive(true);//��ʾUI��
        PlateFoodUIIcon newFoodIcon = GameObject.Instantiate(foodIcon,this.transform);//�½�ʳ��icon
        newFoodIcon.Show(foodMaterialSO.sprite);//��ʾ��ʳ��icon
    }
}
