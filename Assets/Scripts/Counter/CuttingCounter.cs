using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    //[SerializeField] private FoodMaterialSO foodMaterialSO;
    [SerializeField] private CuttingRecipeListSO cuttingRecipeListSO;
    [SerializeField] private CuttingCounter_Visual cuttingAnim;
    [SerializeField] private ProgressBar progressBar;
    public float cuttingcount;

    public static event EventHandler OnCut;
    private void Start()
    {
        cuttingcount = 0;
    }
    public override void Interact(Player player)
    {
        PutFood(player);//��ȡʳ��
    }
    public override void InteractOperate(Player player)
    {
        if (GetFoodMaterial())
        {
            FoodMaterialSO foodMaterialSO = GetFoodMaterial().GetFoodMaterialSO();
            FoodMaterialSO output = cuttingRecipeListSO.GetOutput(foodMaterialSO);
            if (output)
            {
                Cut();
                CuttingRecipe recipe = cuttingRecipeListSO.GetCuttingRecipe(foodMaterialSO);
                progressBar.SetProgress((float)cuttingcount / recipe.cuttingCountMax);//�������������ʾ
                if (cuttingcount>= recipe.cuttingCountMax)
                {
                    DestoryFoodMaterial();//����ʳ��
                    CreateFoodMaterial(output.prefab);//������ʳ��
                    cuttingcount = 0;//����
                    progressBar.Hide();//����������
                }
                cuttingAnim.CounterAnimPlay();//���Ŷ���
                return;
            }
            Debug.Log("��ʳ���޷���Ƭ");
        }
    }
    private void Cut()
    {
        OnCut?.Invoke(this, EventArgs.Empty);//�����в���Ч
        cuttingcount++;
    }
    public static void ClearStaticData()
    {
        OnCut = null;
    }
}
