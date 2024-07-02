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
        if (player.GetFoodMaterial())//玩家手中是否有食材
        {
            OnTrash?.Invoke(this, EventArgs.Empty);//播放丢弃音效
            player.DestoryFoodMaterial();
        }
    }
    public static void ClearStaticData()
    {
        OnTrash = null;
    }
}
