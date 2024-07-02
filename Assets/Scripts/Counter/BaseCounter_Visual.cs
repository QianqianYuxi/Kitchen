using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter_Visual : MonoBehaviour
{
    private Animator anim;//����
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public virtual void CounterAnimPlay()
    {
        Debug.LogWarning("δ��дAnimPlay����");
    }
    public Animator GetCounterAnim()
    {
        return anim;
    }
}
