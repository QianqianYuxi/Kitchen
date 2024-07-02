using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class CookingRecipe {
    [SerializeField] public FoodMaterialSO input;
    [SerializeField] public FoodMaterialSO output;
    [SerializeField] public float CookingTimeMax;
}
