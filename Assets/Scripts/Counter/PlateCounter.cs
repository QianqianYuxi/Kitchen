using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCounter : BaseCounter
{
    [SerializeField] private FoodMaterialSO plateSO;
    [SerializeField] private float spawnRate=3;
    [SerializeField] private int platesCountMax=5; 
    private float timer = 0;
    private List<FoodMaterial> platesList=new List<FoodMaterial>();//�����Ӷ���
    private void Update()
    {
        if(platesList.Count < platesCountMax)
        {
            timer += Time.deltaTime;
        }
        if(timer > spawnRate)//����ˢ��ʱ��
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
                player.AddFoodMaterial(platesList[platesList.Count - 1]);//Ŀ���̨ȡ����
                platesList.RemoveAt(platesList.Count - 1);//��ǰ��̨ɾ��һ������ 
            }
        } 
    }
    public void SpawnPlates()
    {

        FoodMaterial foodMaterial = GameObject.Instantiate(plateSO.prefab, GetHoldPoint()).GetComponent<FoodMaterial>();//ʳ��������ָ��λ��
        foodMaterial.transform.localPosition = Vector3.zero + Vector3.up * 0.1f * platesList.Count;
        platesList.Add(foodMaterial);
    }
}
 