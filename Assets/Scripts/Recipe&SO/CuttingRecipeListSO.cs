using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CuttingRecipeListSO : ScriptableObject
{
    public List<CuttingRecipe> list;//����ʳ���б�

    public FoodMaterialSO GetOutput(FoodMaterialSO input)
    {
        foreach(CuttingRecipe recipe in list)
        {
            if (recipe.input == input)//����ڿ���ʳ����
            {
                return recipe.output;//������Ƭʳ��
            }
        }
        return null;
    }
    public CuttingRecipe GetCuttingRecipe(FoodMaterialSO input)
    {
        foreach (CuttingRecipe recipe in list)
        {
            if (recipe.input == input)//����ڿ���ʳ����
            {
                return recipe;//������Ƭʳ�����
            }
        }
        return null;
    }
}
