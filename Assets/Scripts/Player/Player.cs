using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : FoodMaterialHolder
{
    public static Player Instance { get; private set; }
    [SerializeField] private float movespeed = 5;//速度
    [SerializeField] private float rotatespeed = 10;//转向速度
    [SerializeField] private GameInput gameinput;
    [SerializeField] private LayerMask counterLayerMask;//层级


    private BaseCounter selectedCounter;
    private bool iswalking = false;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameinput.OnInteractAction += Gameinput_OnInteractAction;
        gameinput.OnOperateAction += Gameinput_OnOperateAction;
    }

    private void Gameinput_OnInteractAction(object sender, System.EventArgs e)
    {
        selectedCounter?.Interact(this);
    }
    private void Gameinput_OnOperateAction(object sender, System.EventArgs e)
    {
        selectedCounter?.InteractOperate(this);
    }

    void Update()
    {
        HandleInteraction();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        HandleMovement();
    }

        public bool isWalking
    {
        get
        {
            return iswalking;
        }
    }

    private void HandleMovement()
    {
        Vector3 direction = gameinput.GameInputDirectionNormalized();
        iswalking = direction != Vector3.zero;
        transform.position += direction * Time.deltaTime * movespeed;//单位时间移动
        if (direction != Vector3.zero)//当位置不为0值
        {
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * rotatespeed);//方向柔和变换
        }
    }

    //利用射线检测游戏物体碰撞
    private void HandleInteraction()
    {
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hitinfo, 2f, counterLayerMask))//Raycast返回bool，碰撞物体信息返回给hitinfo,if判断,
        {
            if (hitinfo.transform.TryGetComponent<BaseCounter>(out BaseCounter counter))//尝试获取ClearCounter组件，将获取到的组件给counter
            {
                SetSelectedCounter(counter);
            }
            else
            {
                SetSelectedCounter(null);//无选中
            }
        }
        else
        {
            SetSelectedCounter(null);//无选中
        }
    }

    private void SetSelectedCounter(BaseCounter counter)
    {
        if (counter != selectedCounter)//当前选中非之前选中counter
        {
            selectedCounter?.CancelCounter();//取消之前counter选中
            counter?.SelectCounter();//当前counter选中

            selectedCounter = counter;//改变选中counter
        }
    }


}
