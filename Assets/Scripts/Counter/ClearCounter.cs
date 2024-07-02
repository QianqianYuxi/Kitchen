using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    
    

    //[SerializeField] private bool testing = false;//测试设置
    //[SerializeField] private ClearCounter transferTargetCounter;//目标转移柜台

    //void Update()
    //{
    //    //测试状态且点击鼠标左键
    //    if(testing && Input.GetMouseButtonDown(0) && selectedCounter.activeSelf)
    //    {
    //        TransferFoodMaterials(transferTargetCounter, this);
    //    }
    //}
    // Start is called before the first frame update
    public override void Interact(Player player)//重写方法
    {
        PutFood(player);//放取食物
    }
   
   
}
