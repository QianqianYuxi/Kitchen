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
        PutFood(player);//放取食物
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
                progressBar.SetProgress((float)cuttingcount / recipe.cuttingCountMax);//进度条随进度显示
                if (cuttingcount>= recipe.cuttingCountMax)
                {
                    DestoryFoodMaterial();//消除食材
                    CreateFoodMaterial(output.prefab);//创建新食材
                    cuttingcount = 0;//归零
                    progressBar.Hide();//消除进度条
                }
                cuttingAnim.CounterAnimPlay();//播放动画
                return;
            }
            Debug.Log("该食材无法切片");
        }
    }
    private void Cut()
    {
        OnCut?.Invoke(this, EventArgs.Empty);//播放切菜音效
        cuttingcount++;
    }
    public static void ClearStaticData()
    {
        OnCut = null;
    }
}
