using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter_Visual : BaseCounter_Visual
{
    public override void CounterAnimPlay()
    {
        GetCounterAnim().SetTrigger("Cut");//trigger自动返回false，bool不会
    }
}
