using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CookingRecipeListSO : ScriptableObject
{
    public List<CookingRecipe> list;//建立食谱列表

    public FoodMaterialSO GetOutput(FoodMaterialSO input)
    {
        foreach(CookingRecipe recipe in list)
        {
            if (recipe.input == input)//如果在可煎食谱中
            {
                return recipe.output;//返回煎食物
            }
        }
        return null;
    }
    public CookingRecipe GetCookingRecipe(FoodMaterialSO input)
    {
        foreach (CookingRecipe recipe in list)
        {
            if (recipe.input == input)//如果在可煎食谱中
            {
                return recipe;//返回煎食物菜谱
            }
        }
        return null;
    }
}
