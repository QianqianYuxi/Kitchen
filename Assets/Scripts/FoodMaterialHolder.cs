using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMaterialHolder : MonoBehaviour
{
    [SerializeField] private Transform holdPoint;//食材位置
    private FoodMaterial foodMaterial;//获取食材对象
    public static event EventHandler OnDrop;//放下音效
    public static event EventHandler OnPickUp;//拿起音效
    public Transform GetHoldPoint()
    {
        return holdPoint;
    }//获取物品放置点
    public FoodMaterial GetFoodMaterial()
    {
        return foodMaterial;
    }//获取FoodMaterial对象
    public FoodMaterialSO GetFoodMaterialSO()
    {
        return foodMaterial.GetFoodMaterialSO();
    }//获取FoodMaterialSO对象

    public void SetFoodMaterial(FoodMaterial foodMaterial)
    {
        this.foodMaterial=foodMaterial;
        foodMaterial.transform.localPosition = Vector3.zero;//定位食材与父物体相对位置
    }
    //进行柜台间食材转移功能
    public void TransferFoodMaterials(FoodMaterialHolder targetHolder, FoodMaterialHolder sourceHolder)
    {
        if (targetHolder.GetFoodMaterial() != null)
        {
            Debug.Log("目标持有者已存在食材");
            return;
        }
        if (sourceHolder.GetFoodMaterial() == null)
        {
            Debug.Log("当前持有者未存在食材");
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
        targetHolder.AddFoodMaterial(sourceHolder.GetFoodMaterial());//目标柜台添加食材
        sourceHolder.ClearFoodMaterial();//当前柜台删除食材
    }
    public void ClearFoodMaterial()
    {
        this.foodMaterial = null;
    }
    //添加食材到目标柜台
    public void AddFoodMaterial(FoodMaterial foodMaterial)
    {
        foodMaterial.transform.SetParent(holdPoint);
        foodMaterial.transform.localPosition = Vector3.zero;
        this.foodMaterial = foodMaterial;
    }
    //创建新食材对象
    public void CreateFoodMaterial(GameObject foodMaterialprefab)
    {
        FoodMaterial foodMaterial = GameObject.Instantiate(foodMaterialprefab, GetHoldPoint()).GetComponent<FoodMaterial>();//食材生成至指定位置
        SetFoodMaterial(foodMaterial);//设置更新当前所持食材
    }
    //消除当前食材对象
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
