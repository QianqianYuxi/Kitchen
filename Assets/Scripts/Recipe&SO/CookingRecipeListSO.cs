using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CookingRecipeListSO : ScriptableObject
{
    public List<CookingRecipe> list;//����ʳ���б�

    public FoodMaterialSO GetOutput(FoodMaterialSO input)
    {
        foreach(CookingRecipe recipe in list)
        {
            if (recipe.input == input)//����ڿɼ�ʳ����
            {
                return recipe.output;//���ؼ�ʳ��
            }
        }
        return null;
    }
    public CookingRecipe GetCookingRecipe(FoodMaterialSO input)
    {
        foreach (CookingRecipe recipe in list)
        {
            if (recipe.input == input)//����ڿɼ�ʳ����
            {
                return recipe;//���ؼ�ʳ�����
            }
        }
        return null;
    }
}
