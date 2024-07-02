using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryResultUI : MonoBehaviour
{
    private const string IS_SHOW = "IsShow";

    [SerializeField] private Animator deliverySuccessUIAnim;
    [SerializeField] private Animator deliveryFailUIAnim;

    // Start is called before the first frame update
    void Start()
    {
        OrderManager.Instance.OnRecipeRight += OrderManager_OnRecipeRight;
        OrderManager.Instance.OnRecipeWrong += OrderManager_OnRecipeWrong;
    }

    private void OrderManager_OnRecipeWrong(object sender, System.EventArgs e)
    {
        deliveryFailUIAnim.gameObject.SetActive(true);
        deliveryFailUIAnim.SetTrigger(IS_SHOW);
    }

    private void OrderManager_OnRecipeRight(object sender, System.EventArgs e)
    {
        deliverySuccessUIAnim.gameObject.SetActive(true);
        deliverySuccessUIAnim.SetTrigger(IS_SHOW);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
