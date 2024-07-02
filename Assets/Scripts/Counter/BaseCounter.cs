using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : FoodMaterialHolder
{
    [SerializeField] private GameObject selectedCounter;

    public virtual void Interact(Player player)
    {
        Debug.LogWarning("未重写Interact方法");
    }
    public virtual void InteractOperate(Player player)
    {

    }
    public void SelectCounter()
    {
        selectedCounter.SetActive(true);//显示选中
    }
    public void CancelCounter()
    {
        selectedCounter.SetActive(false);//取消选中
    }
    
    //柜台间食材交互
    public void PutFood(Player player)
    {
        if (player.GetFoodMaterial())//玩家手上有内容
        {
            if (player.GetFoodMaterial()//玩家手上是盘子
                .TryGetComponent<PlateFoodMaterial>(out PlateFoodMaterial plateFoodMaterialOnPlayer))
            {
                if (GetFoodMaterial())//柜台不为空
                {
                    bool isAddSuccess = plateFoodMaterialOnPlayer.AddFoodMaterial(GetFoodMaterialSO());//将柜子上食材放到玩家的盘子上
                    if (isAddSuccess)//食材添加盘子成功
                    {
                        DestoryFoodMaterial();//消除柜台食材
                    }
                }
                else//柜台为空
                {
                    //手持物从玩家转移至桌面
                    TransferFoodMaterials(this, player);
                }
            }
            else//玩家手上没盘子,有其他食材
            {
                if (GetFoodMaterial())//柜台上有内容
                {
                    if (GetFoodMaterial()//柜台上是盘子
                    .TryGetComponent<PlateFoodMaterial>(out PlateFoodMaterial plateFoodMaterialOnCounter))
                    {
                        bool isAddSuccess = plateFoodMaterialOnCounter.AddFoodMaterial(player.GetFoodMaterialSO());//将玩家手中食材放到柜台盘子上
                        if (isAddSuccess)//食材添加盘子成功
                        {
                            player.DestoryFoodMaterial();//消除玩家手中食材
                        }
                    }
                }
                else//柜台为空
                {
                    //食材从玩家手上转移至桌面
                    TransferFoodMaterials(this, player);
                }
            }
        }
        else//玩家手上无内容
        {
            if (GetFoodMaterial())//柜台有物体
            {
                //手持物从桌面转移至玩家手上
                TransferFoodMaterials(player, this);
            }
            else//柜台无物体
            {

            }
        }
    }

}
