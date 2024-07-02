using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearStaticData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //释放重复事件
        CuttingCounter.ClearStaticData();
        TrashCounter.ClearStaticData();
        FoodMaterialHolder.ClearStaticData();
    }
}
