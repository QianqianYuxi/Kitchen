using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private const string MUSICMANAGER_VOLUME = "musicManagerVolume";
    public static MusicManager Instance { get; private set; }
    private AudioSource audioSource;

    private float originalVolume;

    private int volume = 5;//用户设置大小
    private void Awake()
    {
        Instance = this;
        LoadVolume();//加载之前音量
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        originalVolume = audioSource.volume* (volume / 10.0f);
        UpdateVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeVolume()
    {
        volume++;
        if (volume > 10) volume = 0;
        UpdateVolume();
        SaveVolume();//保存当前音量
    }
    public int GetVolume()
    {
        return volume;
    }
    public void UpdateVolume()
    {
        if(volume==0)
        {
            audioSource.enabled = false;//禁用，节省资源
        }
        else
        {
            audioSource.enabled = true;
            audioSource.volume = originalVolume * (volume / 10.0f);
        }
        
    }
    public void SaveVolume()
    {
        PlayerPrefs.SetInt(MUSICMANAGER_VOLUME, volume);
    }
    public void LoadVolume()
    {
        volume = PlayerPrefs.GetInt(MUSICMANAGER_VOLUME, volume);
    }
}
