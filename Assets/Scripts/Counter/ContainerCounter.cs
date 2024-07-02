using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] private FoodMaterialSO foodMaterialSO;//ʳ�����ݶ���
    [SerializeField] private ContainerCounterVisual containerAnim;
    public override void Interact(Player player)
    {
        if (GetFoodMaterial() == null && player.GetFoodMaterial() == null)//��Һ����涼��ʳ��
        {
            CreateFoodMaterial(foodMaterialSO.prefab);
            TransferFoodMaterials(player, this);
            containerAnim.CounterAnimPlay();//����򿪶���
            return;
        }
        PutFood(player);//��ȡʳ��
    }
    
}
