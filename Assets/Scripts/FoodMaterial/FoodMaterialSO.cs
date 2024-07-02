using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]//在unity菜单中可创建
public class FoodMaterialSO : ScriptableObject
{
    [SerializeField] public GameObject prefab;//实体
    [SerializeField] public Sprite sprite;//图标
    [SerializeField] public string objectName;//名字
}
