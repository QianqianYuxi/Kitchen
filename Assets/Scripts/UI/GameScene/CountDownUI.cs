using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownUI : MonoBehaviour
{
    private const string IS_SHAKE = "IsShake";

    [SerializeField] private TextMeshProUGUI numberText;

    private Animator anim;

    private int preNumber=-1;
    private void Start()
    {
        anim = GetComponent<Animator>();
        GameManager.Instance.OnStateChanged += gameManager_OnStateChanged;
    }
    private void Update()
    {
        if (GameManager.Instance.IsCountDownState())
        {
            int nowNumber = Mathf.CeilToInt(GameManager.Instance.GetCountDownTimer());
            if (nowNumber != preNumber)
            {
                anim.SetTrigger(IS_SHAKE);//触发器
                preNumber = nowNumber;
                SoundManager.Instance.OnCountDown();
            }
            numberText.text = nowNumber.ToString();
        }
    }
    private void gameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsCountDownState())//是否是倒计时状态
        {
            numberText.gameObject.SetActive(true);
        }
        else
        {
            numberText.gameObject.SetActive(false);
        }
    }
}
