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
        foreach(FoodMaterialSO_Model item in models)//��������ʳ��ģ�͵��б�
        {
            if (item.foodMaterialSO == foodMaterialSO)//�б����е�ǰʳ��
            {
                item.model.SetActive(true);//��ʾ��ǰʳ��
            }
        }
    }
}
