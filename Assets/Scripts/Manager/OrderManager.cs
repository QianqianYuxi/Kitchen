using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance { get; private set; }
    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeRight;//�ϲ˳ɹ���Ч 
    public event EventHandler OnRecipeWrong;//�ϲ�ʧ����Ч

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

    //State�任�¼�
    private void gameManager_OnStateChanged(object sender, EventArgs e)
    {
        if (GameManager.Instance.IsGamePlayingState())
        {//��Ϸ��ʼ���ƿ�ʼ�µ�
            StartSpawnOrder();
        }
    }

    private void Update()
    {
        if (isStartOrder)//����µ�
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
            OrderNewRecipe();//��һ��
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
            if(IsMealCorrect(recipe, plate))//�ж����ӵ�ǰ��Ʒ�Ƿ��붩���б���ĳ����һ��
            {//�����ϲ��������ϵĶ���
                correctRecipe = recipe;//��ȷ������ֵ
                break;
            }   
        }
        if (!correctRecipe)
        {
            OnRecipeWrong?.Invoke(this, EventArgs.Empty);
            print("�ϲ�ʧ��");
        }
        else
        {
            OnRecipeRight?.Invoke(this, EventArgs.Empty);
            print("�ϲ˳ɹ�");
            orderCount--;//����������
            successDeliveryCount++;//�ɹ��ϲ�������
            orderRecipeSOList.Remove(correctRecipe);//��ɶ��������б����Ƴ�
            OnRecipeSpawned?.Invoke(this, EventArgs.Empty);//����UI
        }
    }

    private bool IsMealCorrect(RecipeSO recipe, PlateFoodMaterial plate)
    {
        List<FoodMaterialSO> list1 = recipe.foodMaterialSOList;//��ǰ��˲˵��б�
        List<FoodMaterialSO> list2 = plate.GetFoodMaterialSOList();//��ǰ������ʳ���б�

        //�ж������Ƿ�Ϊ��
        if (list2.Count==0)
        {
            return false;
        }
        //�ж�ʳ�������Ƿ�һ��
        if (list1.Count != list2.Count) return false;

        //�ж�ʳ���Ƿ�һ��
        foreach(FoodMaterialSO foodMaterial in list1)//����ʳ����������ʳ��
        {
            if (!list2.Contains(foodMaterial)){//�����������ʳ������ʳ��
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