using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]//��unity�˵��пɴ���
public class FoodMaterialSO : ScriptableObject
{
    [SerializeField] public GameObject prefab;//ʵ��
    [SerializeField] public Sprite sprite;//ͼ��
    [SerializeField] public string objectName;//����
}
