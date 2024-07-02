using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private const string SOUNDMANAGER_VOLUME = "soundManagerVolume";
    public static SoundManager Instance { get; private set; }
    [SerializeField] private AudioClipRefsSO audioClipRefsSO;

    private int volume = 5;
    private void Awake()
    {
        Instance = this;
        LoadVolume();//游戏开始便获取音量值
    }
    private void Start()
    {
        OrderManager.Instance.OnRecipeRight += OrderManager_OnRecipeRight;
        OrderManager.Instance.OnRecipeWrong += OrdeManager_OnRecipeWrong;
        CuttingCounter.OnCut += CuttingCounter_OnCut;
        FoodMaterialHolder.OnPickUp += FoodMaterialHolder_OnPickUp;
        FoodMaterialHolder.OnDrop += FoodMaterialHolder_OnDrop;
        TrashCounter.OnTrash += TrashCounter_OnTrash;
    }

    private void StoveCounter_OnFrying(object sender, System.EventArgs e)
    {
        PlayAudioClip(audioClipRefsSO.panSizzleLoop);
    }

    private void Player_OnWalking(object sender, System.EventArgs e)
    {
        PlayAudioClip(audioClipRefsSO.footStep);
    }

    private void TrashCounter_OnTrash(object sender, System.EventArgs e)
    {
        PlayAudioClip(audioClipRefsSO.trash);
    }

    private void FoodMaterialHolder_OnDrop(object sender, System.EventArgs e)
    {
        PlayAudioClip(audioClipRefsSO.objectDrop);
    }

    private void FoodMaterialHolder_OnPickUp(object sender, System.EventArgs e)
    {
        PlayAudioClip(audioClipRefsSO.objectPickup);
    }

    private void FoodMaterialHolder_OnTrash(object sender, System.EventArgs e)
    {
        print("trash");
        PlayAudioClip(audioClipRefsSO.trash);
    }

    private void CuttingCounter_OnCut(object sender, System.EventArgs e)
    {
        PlayAudioClip(audioClipRefsSO.chop);
    }

    private void OrdeManager_OnRecipeWrong(object sender, System.EventArgs e)
    {
        PlayAudioClip(audioClipRefsSO.deliveryFail);
    }

    private void OrderManager_OnRecipeRight(object sender, System.EventArgs e)
    {
        PlayAudioClip(audioClipRefsSO.deliverySuccess);
    }
    public void OnWarning()
    {
        PlayAudioClip(audioClipRefsSO.warning);
    }
    private void OnFrying()
    {
        PlayAudioClip(audioClipRefsSO.panSizzleLoop);
    }
    public void OnWalking(float volumeMutipler=.1f)
    {
        PlayAudioClip(audioClipRefsSO.footStep,volumeMutipler);
    }
    public void OnCountDown()
    {
        PlayAudioClip(audioClipRefsSO.warning);
    }
    private void PlayAudioClip(AudioClip[] audioClips, float volumeMutipler = 0.1f)
    {//播放音效
        PlayAudioClip(audioClips, Camera.main.transform.position,volumeMutipler);
    }
    private void PlayAudioClip(AudioClip[] audioClips, Vector3 position,float volumeMutipler)
    {//播放音效
        if (volume == 0) return;//优化
        int index = Random.Range(0, audioClips.Length);
        AudioSource.PlayClipAtPoint(audioClips[index], position,volumeMutipler*(volume/10.0f));
    }
    public void ChangeVolume()
    {
        //volume 0-10
        volume++;
        if (volume > 10) volume = 0;
        SaveVolume();//保存当前音量
    }
    public int GetVolume()
    {
        return volume;
    }
    public void SaveVolume()
    {
        PlayerPrefs.SetInt(SOUNDMANAGER_VOLUME, volume);//保存当前音量值
    }
    public void LoadVolume()
    {
        volume=PlayerPrefs.GetInt(SOUNDMANAGER_VOLUME, volume);//获取保存的音量值
    }
}
