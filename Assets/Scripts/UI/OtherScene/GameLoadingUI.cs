using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameLoadingUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI loadingDot;
    private float dotRate=0.3f;//�����ʱ��

    private void Start()
    {
        StartCoroutine(DotAnimation());
    }
    IEnumerator DotAnimation()
    {
        while (true)
        {
            loadingDot.text = ".";
            yield return new WaitForSeconds(dotRate);
            loadingDot.text = "..";
            yield return new WaitForSeconds(dotRate);
            loadingDot.text = "...";
            yield return new WaitForSeconds(dotRate);
            loadingDot.text = "....";
            yield return new WaitForSeconds(dotRate);
            loadingDot.text = ".....";
            yield return new WaitForSeconds(dotRate);
            loadingDot.text = "......";
            yield return new WaitForSeconds(dotRate);
        }
    }
}
