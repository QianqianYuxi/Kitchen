using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : FoodMaterialHolder
{
    [SerializeField] private GameObject selectedCounter;

    public virtual void Interact(Player player)
    {
        Debug.LogWarning("δ��дInteract����");
    }
    public virtual void InteractOperate(Player player)
    {

    }
    public void SelectCounter()
    {
        selectedCounter.SetActive(true);//��ʾѡ��
    }
    public void CancelCounter()
    {
        selectedCounter.SetActive(false);//ȡ��ѡ��
    }
    
    //��̨��ʳ�Ľ���
    public void PutFood(Player player)
    {
        if (player.GetFoodMaterial())//�������������
        {
            if (player.GetFoodMaterial()//�������������
                .TryGetComponent<PlateFoodMaterial>(out PlateFoodMaterial plateFoodMaterialOnPlayer))
            {
                if (GetFoodMaterial())//��̨��Ϊ��
                {
                    bool isAddSuccess = plateFoodMaterialOnPlayer.AddFoodMaterial(GetFoodMaterialSO());//��������ʳ�ķŵ���ҵ�������
                    if (isAddSuccess)//ʳ��������ӳɹ�
                    {
                        DestoryFoodMaterial();//������̨ʳ��
                    }
                }
                else//��̨Ϊ��
                {
                    //�ֳ�������ת��������
                    TransferFoodMaterials(this, player);
                }
            }
            else//�������û����,������ʳ��
            {
                if (GetFoodMaterial())//��̨��������
                {
                    if (GetFoodMaterial()//��̨��������
                    .TryGetComponent<PlateFoodMaterial>(out PlateFoodMaterial plateFoodMaterialOnCounter))
                    {
                        bool isAddSuccess = plateFoodMaterialOnCounter.AddFoodMaterial(player.GetFoodMaterialSO());//���������ʳ�ķŵ���̨������
                        if (isAddSuccess)//ʳ��������ӳɹ�
                        {
                            player.DestoryFoodMaterial();//�����������ʳ��
                        }
                    }
                }
                else//��̨Ϊ��
                {
                    //ʳ�Ĵ��������ת��������
                    TransferFoodMaterials(this, player);
                }
            }
        }
        else//�������������
        {
            if (GetFoodMaterial())//��̨������
            {
                //�ֳ��������ת�����������
                TransferFoodMaterials(player, this);
            }
            else//��̨������
            {

            }
        }
    }

}
