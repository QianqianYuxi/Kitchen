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
        gameObject.SetActive(true);//显示UI条
        PlateFoodUIIcon newFoodIcon = GameObject.Instantiate(foodIcon,this.transform);//新建食材icon
        newFoodIcon.Show(foodMaterialSO.sprite);//显示新食材icon
    }
}
