using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] private FoodMaterialSO foodMaterialSO;//食材数据对象
    [SerializeField] private ContainerCounterVisual containerAnim;
    public override void Interact(Player player)
    {
        if (GetFoodMaterial() == null && player.GetFoodMaterial() == null)//玩家和桌面都无食材
        {
            CreateFoodMaterial(foodMaterialSO.prefab);
            TransferFoodMaterials(player, this);
            containerAnim.CounterAnimPlay();//冰箱打开动画
            return;
        }
        PutFood(player);//放取食物
    }
    
}
