using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateFoodMaterial : FoodMaterial
{
    [SerializeField] private List<FoodMaterialSO> PlateAddFoodMaterialSOList = new List<FoodMaterialSO>();//�ɷ����������ϵ�ʳ���б�
    private List<FoodMaterialSO> foodMaterialSOList = new List<FoodMaterialSO>();//������ʳ���б�
    [SerializeField] private PlateFoodMaterial_Visual plateVisual;
    [SerializeField] private PlateFoodUI plateUI;

    public bool AddFoodMaterial(FoodMaterialSO foodMaterialSO)//�����������ʳ��
    {
        if(foodMaterialSOList.Contains(foodMaterialSO) || 
            !PlateAddFoodMaterialSOList.Contains(foodMaterialSO))
        {//���������е�ǰʳ�ģ����߲����ڿɷ����������ϵ�ʳ��
            return false;//���ʧ��
        }
        foodMaterialSOList.Add(foodMaterialSO);//ʳ�������������
        plateVisual.ShowFoodMaterial(foodMaterialSO);//��ʾ��ǰʳ��
        plateUI.ShowPlateFoodUI(foodMaterialSO);//��ʾʳ��UI
        return true;
    }
    public List<FoodMaterialSO> GetFoodMaterialSOList()//���������ϵ�ʳ���б�
    {
        return foodMaterialSOList;
    }
}
