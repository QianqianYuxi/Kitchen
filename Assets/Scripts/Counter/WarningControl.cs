using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningControl : MonoBehaviour
{
    private const string IS_WARNING = "IsWarning";

    [SerializeField]private GameObject warningUI;
    [SerializeField]private Animator progressBarAnimator;

    private bool isWarning = false;//�Ƿ��ھ���
    private float warningSoundRate = .2f;
    private float warningSoundTimer = 0;
    private void Start()
    {
        StopWarning();
    }
    // Start is called before the first frame update
    private void Update()
    {
        if (isWarning)
        {
            warningSoundTimer += Time.deltaTime;
            if (warningSoundTimer > warningSoundRate)//�жϾ����������ʱ��
            {
                SoundManager.Instance.OnWarning();
                warningSoundTimer = 0;//����
            }
        }
    }
    public void ShowWarning()
    {
        if (isWarning == false)
        {
            isWarning = true;
            warningUI.SetActive(true);
            progressBarAnimator.SetBool(IS_WARNING, true);
        }
    }

    // Update is called once per frame
    public void StopWarning()
    {
        if (isWarning == true)
        {
            isWarning = false;
            warningUI.SetActive(false);
            progressBarAnimator.SetBool(IS_WARNING, false);
        }
        
    }
}
