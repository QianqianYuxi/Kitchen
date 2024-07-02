using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    [SerializeField]private OrderManager orderManager;
    public override void Interact(Player player)
    {
        if(player.GetFoodMaterial() &&
                player.GetFoodMaterial().TryGetComponent<PlateFoodMaterial>(out PlateFoodMaterial plate))
        {
            //TODO �ж��ϲ��Ƿ���ȷ
            orderManager.DeliveryRecipe(plate);
            player.DestoryFoodMaterial();
        }
    }
}
