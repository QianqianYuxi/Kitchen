using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCounter : BaseCounter
{
    [SerializeField] private FoodMaterialSO plateSO;
    [SerializeField] private float spawnRate=3;
    [SerializeField] private int platesCountMax=5; 
    private float timer = 0;
    private List<FoodMaterial> platesList=new List<FoodMaterial>();//摞盘子队列
    private void Update()
    {
        if(platesList.Count < platesCountMax)
        {
            timer += Time.deltaTime;
        }
        if(timer > spawnRate)//但到刷新时间
        {
            SpawnPlates();
            timer = 0;
        }
    }
    public override void Interact(Player player)
    {
        if (!player.GetFoodMaterial())
        {
            if (platesList.Count > 0)
            {
                player.AddFoodMaterial(platesList[platesList.Count - 1]);//目标柜台取盘子
                platesList.RemoveAt(platesList.Count - 1);//当前柜台删除一个盘子 
            }
        } 
    }
    public void SpawnPlates()
    {

        FoodMaterial foodMaterial = GameObject.Instantiate(plateSO.prefab, GetHoldPoint()).GetComponent<FoodMaterial>();//食材生成至指定位置
        foodMaterial.transform.localPosition = Vector3.zero + Vector3.up * 0.1f * platesList.Count;
        platesList.Add(foodMaterial);
    }
}
 