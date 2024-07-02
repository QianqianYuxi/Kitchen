using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private const string MUSICMANAGER_VOLUME = "musicManagerVolume";
    public static MusicManager Instance { get; private set; }
    private AudioSource audioSource;

    private float originalVolume;

    private int volume = 5;//�û����ô�С
    private void Awake()
    {
        Instance = this;
        LoadVolume();//����֮ǰ����
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
        SaveVolume();//���浱ǰ����
    }
    public int GetVolume()
    {
        return volume;
    }
    public void UpdateVolume()
    {
        if(volume==0)
        {
            audioSource.enabled = false;//���ã���ʡ��Դ
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
