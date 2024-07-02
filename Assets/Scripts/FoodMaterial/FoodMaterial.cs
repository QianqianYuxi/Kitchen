using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMaterial : MonoBehaviour
{
    [SerializeField] private FoodMaterialSO foodMaterialSO;
    public FoodMaterialSO GetFoodMaterialSO()
    {
        return foodMaterialSO;
    }
    
}
