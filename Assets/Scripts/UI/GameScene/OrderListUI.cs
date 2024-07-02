using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderListUI : MonoBehaviour
{
    [SerializeField] private Transform recipeParent;
    [SerializeField] private RecipeUI recipeUITenplate;
    //[SerializeField] private OrderManager orderManager;

    private void Start()
    {
        recipeUITenplate.gameObject.SetActive(false);
        OrderManager.Instance.OnRecipeSpawned += OrderManager_OnRecipeSpawned;
    }
    private void OrderManager_OnRecipeSpawned(object sender,System.EventArgs e)
    {
        UpDateUI();
    }
    private void UpDateUI()
    {
        foreach(Transform child in recipeParent)
        {
            if (child != recipeUITenplate.transform)
            {
                Destroy(child.gameObject);
            }
        }

        List<RecipeSO> recipeSOList = OrderManager.Instance.GetOrderList();
        foreach(RecipeSO recipeSO in recipeSOList)
        {
            RecipeUI recipeUI = GameObject.Instantiate(recipeUITenplate, this.transform);
            recipeUI.gameObject.SetActive(true);
            recipeUI.UpDateUI(recipeSO);
        }
    }
}
