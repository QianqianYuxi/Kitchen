using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterVisual : BaseCounter_Visual
{
    public override void CounterAnimPlay()
    {
        GetCounterAnim().SetTrigger("OpenClose");//trigger�Զ�����false��bool����
    }
}
