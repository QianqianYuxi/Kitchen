using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlateFoodMaterial_Visual : MonoBehaviour
{
    [Serializable]
    public class FoodMaterialSO_Model
    {
        public FoodMaterialSO foodMaterialSO;
        public GameObject model;
    }
    [SerializeField]private List<FoodMaterialSO_Model> models;
    public void ShowFoodMaterial(FoodMaterialSO foodMaterialSO)
    {
        foreach(FoodMaterialSO_Model item in models)//遍历关联食材模型的列表
        {
            if (item.foodMaterialSO == foodMaterialSO)//列表中有当前食材
            {
                item.model.SetActive(true);//显示当前食材
            }
        }
    }
}
