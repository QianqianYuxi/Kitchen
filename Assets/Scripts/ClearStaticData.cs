using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearStaticData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //�ͷ��ظ��¼�
        CuttingCounter.ClearStaticData();
        TrashCounter.ClearStaticData();
        FoodMaterialHolder.ClearStaticData();
    }
}
