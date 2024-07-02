using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateFoodMaterial : FoodMaterial
{
    [SerializeField] private List<FoodMaterialSO> PlateAddFoodMaterialSOList = new List<FoodMaterialSO>();//可放置盘子身上的食材列表
    private List<FoodMaterialSO> foodMaterialSOList = new List<FoodMaterialSO>();//盘子上食物列表
    [SerializeField] private PlateFoodMaterial_Visual plateVisual;
    [SerializeField] private PlateFoodUI plateUI;

    public bool AddFoodMaterial(FoodMaterialSO foodMaterialSO)//向盘子上添加食材
    {
        if(foodMaterialSOList.Contains(foodMaterialSO) || 
            !PlateAddFoodMaterialSOList.Contains(foodMaterialSO))
        {//盘子中已有当前食材，或者不属于可放置在盘子上的食材
            return false;//添加失败
        }
        foodMaterialSOList.Add(foodMaterialSO);//食材添加至盘子中
        plateVisual.ShowFoodMaterial(foodMaterialSO);//显示当前食材
        plateUI.ShowPlateFoodUI(foodMaterialSO);//显示食材UI
        return true;
    }
    public List<FoodMaterialSO> GetFoodMaterialSOList()//返回盘子上的食物列表
    {
        return foodMaterialSOList;
    }
}
