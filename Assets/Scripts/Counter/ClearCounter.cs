using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    
    

    //[SerializeField] private bool testing = false;//��������
    //[SerializeField] private ClearCounter transferTargetCounter;//Ŀ��ת�ƹ�̨

    //void Update()
    //{
    //    //����״̬�ҵ��������
    //    if(testing && Input.GetMouseButtonDown(0) && selectedCounter.activeSelf)
    //    {
    //        TransferFoodMaterials(transferTargetCounter, this);
    //    }
    //}
    // Start is called before the first frame update
    public override void Interact(Player player)//��д����
    {
        PutFood(player);//��ȡʳ��
    }
   
   
}
