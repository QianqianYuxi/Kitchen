using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class RecipeSO : ScriptableObject
{
    public string reciplename;//����
    public List<FoodMaterialSO> foodMaterialSOList; 
}
