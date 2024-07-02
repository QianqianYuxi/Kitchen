using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMaterialHolder : MonoBehaviour
{
    [SerializeField] private Transform holdPoint;//ʳ��λ��
    private FoodMaterial foodMaterial;//��ȡʳ�Ķ���
    public static event EventHandler OnDrop;//������Ч
    public static event EventHandler OnPickUp;//������Ч
    public Transform GetHoldPoint()
    {
        return holdPoint;
    }//��ȡ��Ʒ���õ�
    public FoodMaterial GetFoodMaterial()
    {
        return foodMaterial;
    }//��ȡFoodMaterial����
    public FoodMaterialSO GetFoodMaterialSO()
    {
        return foodMaterial.GetFoodMaterialSO();
    }//��ȡFoodMaterialSO����

    public void SetFoodMaterial(FoodMaterial foodMaterial)
    {
        this.foodMaterial=foodMaterial;
        foodMaterial.transform.localPosition = Vector3.zero;//��λʳ���븸�������λ��
    }
    //���й�̨��ʳ��ת�ƹ���
    public void TransferFoodMaterials(FoodMaterialHolder targetHolder, FoodMaterialHolder sourceHolder)
    {
        if (targetHolder.GetFoodMaterial() != null)
        {
            Debug.Log("Ŀ��������Ѵ���ʳ��");
            return;
        }
        if (sourceHolder.GetFoodMaterial() == null)
        {
            Debug.Log("��ǰ������δ����ʳ��");
            return;
        }
        if (targetHolder.GetComponent<Player>())
        {
            OnPickUp?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            OnDrop?.Invoke(this, EventArgs.Empty);
        }
        targetHolder.AddFoodMaterial(sourceHolder.GetFoodMaterial());//Ŀ���̨���ʳ��
        sourceHolder.ClearFoodMaterial();//��ǰ��̨ɾ��ʳ��
    }
    public void ClearFoodMaterial()
    {
        this.foodMaterial = null;
    }
    //���ʳ�ĵ�Ŀ���̨
    public void AddFoodMaterial(FoodMaterial foodMaterial)
    {
        foodMaterial.transform.SetParent(holdPoint);
        foodMaterial.transform.localPosition = Vector3.zero;
        this.foodMaterial = foodMaterial;
    }
    //������ʳ�Ķ���
    public void CreateFoodMaterial(GameObject foodMaterialprefab)
    {
        FoodMaterial foodMaterial = GameObject.Instantiate(foodMaterialprefab, GetHoldPoint()).GetComponent<FoodMaterial>();//ʳ��������ָ��λ��
        SetFoodMaterial(foodMaterial);//���ø��µ�ǰ����ʳ��
    }
    //������ǰʳ�Ķ���
    public void DestoryFoodMaterial()
    {
        Destroy(foodMaterial.gameObject);
        ClearFoodMaterial();
    }
    public static void ClearStaticData()
    {
        OnDrop = null;
        OnPickUp = null;
    }
}
