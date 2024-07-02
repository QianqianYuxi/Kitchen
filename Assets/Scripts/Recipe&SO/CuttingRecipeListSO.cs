using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CuttingRecipeListSO : ScriptableObject
{
    public List<CuttingRecipe> list;//建立食谱列表

    public FoodMaterialSO GetOutput(FoodMaterialSO input)
    {
        foreach(CuttingRecipe recipe in list)
        {
            if (recipe.input == input)//如果在可切食谱中
            {
                return recipe.output;//返回切片食物
            }
        }
        return null;
    }
    public CuttingRecipe GetCuttingRecipe(FoodMaterialSO input)
    {
        foreach (CuttingRecipe recipe in list)
        {
            if (recipe.input == input)//如果在可切食谱中
            {
                return recipe;//返回切片食物菜谱
            }
        }
        return null;
    }
}
