using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private Player player;
    private AudioSource onWalking;
    [SerializeField] private float stepTime;
    private float stepTimer=0;
    private void Update()
    {
        PlayWalkingStepSound();
    }
    public void PlayWalkingStepSound()
    {
        if (player.isWalking)
        {
            stepTimer += Time.deltaTime;
            if(stepTimer > stepTime)
            {
                SoundManager.Instance.OnWalking(0.5f);
                stepTimer = 0;
            }
        }
    }
}
