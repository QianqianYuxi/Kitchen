using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : BaseCounter
{
    public static event EventHandler OnTrash;


    // Start is called before the first frame update
    public override void Interact(Player player)
    {
        if (player.GetFoodMaterial())//��������Ƿ���ʳ��
        {
            OnTrash?.Invoke(this, EventArgs.Empty);//���Ŷ�����Ч
            player.DestoryFoodMaterial();
        }
    }
    public static void ClearStaticData()
    {
        OnTrash = null;
    }
}
