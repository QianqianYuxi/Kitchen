using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : BaseCounter
{
    [SerializeField] private CookingRecipeListSO cookingRecipeListSO;//煎食材对象
    [SerializeField] private StoveCounter_Visual stoveCounter_Visual;
    [SerializeField] private ProgressBar progressBar;//进度条
    [SerializeField] private AudioSource onFrying;
    private bool isCooking=false;//是否在煎
    private float cookingTime=0;

    //private FoodMaterialSO outFoodSO;//拿走的食材
    //private FoodMaterialSO inFoodSO;//放入的食材 

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
        if (GetFoodMaterial() && !player.GetFoodMaterial())//桌面有食材，玩家无
        {
            //食材从桌面转移至玩家
            //outFoodSO = GetFoodMaterial().GetFoodMaterialSO();//拿走的食材对象
            TransferFoodMaterials(player, this);
            progressBar.Hide();//隐藏进度条
            warningControl.StopWarning();//停止警告
            isCooking = false;
        }
        else if(!GetFoodMaterial() && player.GetFoodMaterial())//桌面无食材，玩家有
        {
            FoodMaterialSO foodMaterialSO = player.GetFoodMaterial().GetFoodMaterialSO();
            FoodMaterialSO output = cookingRecipeListSO.GetOutput(foodMaterialSO);
            if (output)//如果食材属于可煎食材
            {
                //食材从玩家转移至桌面
                TransferFoodMaterials(this, player);
                //inFoodSO = foodMaterialSO;//放入的食材对象
                //if (outFoodSO != inFoodSO)//煎一个新肉饼{ cookingTime = 0;//煎肉时间归0}
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
                    cookingTime += Time.deltaTime;//计算煎肉时间
                    CookingRecipe recipe = cookingRecipeListSO.GetCookingRecipe(foodMaterialSO);
                    float progress = (float)cookingTime / recipe.CookingTimeMax;
                    progressBar.SetProgress(progress);//设置当前进度条进度
                    if (cookingTime >= recipe.CookingTimeMax)
                    {
                        DestoryFoodMaterial();//消除原有食材
                        CreateFoodMaterial(output.prefab);//生成新食材
                        cookingTime = 0;
                        progressBar.Hide();//隐藏进度条
                    }
                float warningTimeNormalize = .2f;//界定提醒状态时间
                if (output.objectName=="烧焦肉饼"&& progress>warningTimeNormalize)//处于烧焦状态
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
