using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance { get; private set; }
    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeRight;//上菜成功音效 
    public event EventHandler OnRecipeWrong;//上菜失败音效

    [SerializeField] private RecipeListSO recipeListSO;
    [SerializeField] private List<RecipeSO> orderRecipeSOList = new List<RecipeSO>();

    [SerializeField] private int orderCountMax =5;
    [SerializeField] private float orderRate=3;
    private float orderTimer = 0;
    [SerializeField]private bool isStartOrder = false;
    private int orderCount = 0;
    private int successDeliveryCount = 0;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        GameManager.Instance.OnStateChanged += gameManager_OnStateChanged;
    }

    //State变换事件
    private void gameManager_OnStateChanged(object sender, EventArgs e)
    {
        if (GameManager.Instance.IsGamePlayingState())
        {//游戏开始控制开始下单
            StartSpawnOrder();
        }
    }

    private void Update()
    {
        if (isStartOrder)//如果下单
        {
            OrderUpdate();
        }
    }

    private void OrderUpdate()
    {
        orderTimer += Time.deltaTime;
        if (orderTimer >= orderRate)
        {
            orderTimer = 0;
            OrderNewRecipe();//下一单
        }
    }
    private void OrderNewRecipe()
    {
        if (orderCount >= orderCountMax)
        {
            return;
        }
        orderCount++;
        int index = UnityEngine.Random.Range(0, recipeListSO.recipeSOList.Count);
        orderRecipeSOList.Add(recipeListSO.recipeSOList[index]);
        OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
    }

    public void DeliveryRecipe(PlateFoodMaterial plate)
    {
        RecipeSO correctRecipe = null;
        foreach(RecipeSO recipe in orderRecipeSOList)
        {
            if(IsMealCorrect(recipe, plate))//判断盘子当前菜品是否与订单列表中某订单一致
            {//有与上菜条件符合的订单
                correctRecipe = recipe;//正确订单赋值
                break;
            }   
        }
        if (!correctRecipe)
        {
            OnRecipeWrong?.Invoke(this, EventArgs.Empty);
            print("上菜失败");
        }
        else
        {
            OnRecipeRight?.Invoke(this, EventArgs.Empty);
            print("上菜成功");
            orderCount--;//订单数减少
            successDeliveryCount++;//成功上菜数增加
            orderRecipeSOList.Remove(correctRecipe);//完成订单，从列表中移除
            OnRecipeSpawned?.Invoke(this, EventArgs.Empty);//更新UI
        }
    }

    private bool IsMealCorrect(RecipeSO recipe, PlateFoodMaterial plate)
    {
        List<FoodMaterialSO> list1 = recipe.foodMaterialSOList;//当前点菜菜单列表
        List<FoodMaterialSO> list2 = plate.GetFoodMaterialSOList();//当前盘子上食物列表

        //判断盘子是否为空
        if (list2.Count==0)
        {
            return false;
        }
        //判断食材数量是否一致
        if (list1.Count != list2.Count) return false;

        //判断食材是否一致
        foreach(FoodMaterialSO foodMaterial in list1)//遍历食谱与盘子上食材
        {
            if (!list2.Contains(foodMaterial)){//如果盘子上无食谱所需食材
                return false;
            }
        }
        return true;
    }

    public List<RecipeSO> GetOrderList()
    {
        return orderRecipeSOList;
    }
    public void StartSpawnOrder()
    {
        isStartOrder = true;
    }
    public int GetSuccessDeliveryCount()
    {
        return successDeliveryCount;
    }
}