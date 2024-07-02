using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : FoodMaterialHolder
{
    public static Player Instance { get; private set; }
    [SerializeField] private float movespeed = 5;//�ٶ�
    [SerializeField] private float rotatespeed = 10;//ת���ٶ�
    [SerializeField] private GameInput gameinput;
    [SerializeField] private LayerMask counterLayerMask;//�㼶


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
        transform.position += direction * Time.deltaTime * movespeed;//��λʱ���ƶ�
        if (direction != Vector3.zero)//��λ�ò�Ϊ0ֵ
        {
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * rotatespeed);//������ͱ任
        }
    }

    //�������߼����Ϸ������ײ
    private void HandleInteraction()
    {
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hitinfo, 2f, counterLayerMask))//Raycast����bool����ײ������Ϣ���ظ�hitinfo,if�ж�,
        {
            if (hitinfo.transform.TryGetComponent<BaseCounter>(out BaseCounter counter))//���Ի�ȡClearCounter���������ȡ���������counter
            {
                SetSelectedCounter(counter);
            }
            else
            {
                SetSelectedCounter(null);//��ѡ��
            }
        }
        else
        {
            SetSelectedCounter(null);//��ѡ��
        }
    }

    private void SetSelectedCounter(BaseCounter counter)
    {
        if (counter != selectedCounter)//��ǰѡ�з�֮ǰѡ��counter
        {
            selectedCounter?.CancelCounter();//ȡ��֮ǰcounterѡ��
            counter?.SelectCounter();//��ǰcounterѡ��

            selectedCounter = counter;//�ı�ѡ��counter
        }
    }


}
