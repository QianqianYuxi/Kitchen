using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter_Visual : MonoBehaviour
{
    private Animator anim;//动画
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public virtual void CounterAnimPlay()
    {
        Debug.LogWarning("未重写AnimPlay方法");
    }
    public Animator GetCounterAnim()
    {
        return anim;
    }
}
