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

    private static Scene targetScene;//目标加载场景

    public static void Load(Scene target)
    {
        Time.timeScale = 1;//加载新场景时间恢复
        targetScene = target;//设置目标加载场景
        SceneManager.LoadScene((int)Scene.LoadScene);//加载loading场景
    }
    public static void LoadBack()//回调
    {
        SceneManager.LoadScene((int)targetScene);//加载目标场景
    }
}
