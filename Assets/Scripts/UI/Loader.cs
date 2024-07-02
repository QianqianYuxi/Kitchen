using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    // Start is called before the first frame update
    public enum Scene
    {
        GameMenu,
        LoadScene,
        GameScene
    }

    private static Scene targetScene;//Ŀ����س���

    public static void Load(Scene target)
    {
        Time.timeScale = 1;//�����³���ʱ��ָ�
        targetScene = target;//����Ŀ����س���
        SceneManager.LoadScene((int)Scene.LoadScene);//����loading����
    }
    public static void LoadBack()//�ص�
    {
        SceneManager.LoadScene((int)targetScene);//����Ŀ�곡��
    }
}
