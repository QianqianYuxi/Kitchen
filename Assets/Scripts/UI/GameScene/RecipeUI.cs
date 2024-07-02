using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipeNameText;
    [SerializeField] private Transform foodMaterialParent;
    [SerializeField] private Image iconUITemplete;

    private void Start()
    {
        iconUITemplete.gameObject.SetActive(false);
    }
    public void UpDateUI(RecipeSO recipeSO)
    {
        recipeNameText.text = recipeSO.reciplename;
        foreach(FoodMaterialSO foodMaterialSO in recipeSO.foodMaterialSOList)//������ǰ�˵Ĳ���ʳ��
        {
            Image newIcon = GameObject.Instantiate(iconUITemplete, foodMaterialParent.transform);
            newIcon.sprite = foodMaterialSO.sprite;
            newIcon.gameObject.SetActive(true);
        }
    }
}
