using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : BaseCounter
{
    [SerializeField] private CookingRecipeListSO cookingRecipeListSO;//��ʳ�Ķ���
    [SerializeField] private StoveCounter_Visual stoveCounter_Visual;
    [SerializeField] private ProgressBar progressBar;//������
    [SerializeField] private AudioSource onFrying;
    private bool isCooking=false;//�Ƿ��ڼ�
    private float cookingTime=0;

    //private FoodMaterialSO outFoodSO;//���ߵ�ʳ��
    //private FoodMaterialSO inFoodSO;//�����ʳ�� 

    public static event EventHandler OnFrying;
    private WarningControl warningControl;
    private void Start()
    {
        warningControl = GetComponent<WarningControl>();
    }
    private void Update()
    {
        Cooking();
    }
    public override void Interact(Player player)
    {
        if (GetFoodMaterial() && !player.GetFoodMaterial())//������ʳ�ģ������
        {
            //ʳ�Ĵ�����ת�������
            //outFoodSO = GetFoodMaterial().GetFoodMaterialSO();//���ߵ�ʳ�Ķ���
            TransferFoodMaterials(player, this);
            progressBar.Hide();//���ؽ�����
            warningControl.StopWarning();//ֹͣ����
            isCooking = false;
        }
        else if(!GetFoodMaterial() && player.GetFoodMaterial())//������ʳ�ģ������
        {
            FoodMaterialSO foodMaterialSO = player.GetFoodMaterial().GetFoodMaterialSO();
            FoodMaterialSO output = cookingRecipeListSO.GetOutput(foodMaterialSO);
            if (output)//���ʳ�����ڿɼ�ʳ��
            {
                //ʳ�Ĵ����ת��������
                TransferFoodMaterials(this, player);
                //inFoodSO = foodMaterialSO;//�����ʳ�Ķ���
                //if (outFoodSO != inFoodSO)//��һ�������{ cookingTime = 0;//����ʱ���0}
                isCooking = true;
                onFrying.Play();
            }
                
        }
    }

    public void Cooking()
    {
        stoveCounter_Visual.CookingPlay(isCooking);
        if (isCooking)
            {
                FoodMaterialSO foodMaterialSO = GetFoodMaterial().GetFoodMaterialSO();
                FoodMaterialSO output = cookingRecipeListSO.GetOutput(foodMaterialSO);
                if (output)
                {
                    cookingTime += Time.deltaTime;//�������ʱ��
                    CookingRecipe recipe = cookingRecipeListSO.GetCookingRecipe(foodMaterialSO);
                    float progress = (float)cookingTime / recipe.CookingTimeMax;
                    progressBar.SetProgress(progress);//���õ�ǰ����������
                    if (cookingTime >= recipe.CookingTimeMax)
                    {
                        DestoryFoodMaterial();//����ԭ��ʳ��
                        CreateFoodMaterial(output.prefab);//������ʳ��
                        cookingTime = 0;
                        progressBar.Hide();//���ؽ�����
                    }
                float warningTimeNormalize = .2f;//�綨����״̬ʱ��
                if (output.objectName=="�ս����"&& progress>warningTimeNormalize)//�����ս�״̬
                    {
                        warningControl.ShowWarning();
                    }
                }
            }
        else
        {
            onFrying.Pause();
        }
        }
}
