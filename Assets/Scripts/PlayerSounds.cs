using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioClip jumpAudio;
    public AudioClip rootingAudio;
    public AudioClip unRootingAudio;
    public AudioClip deadAudio;

    public void JumpAudio()
    {
        AudioManager.instance.PlaySfx(jumpAudio);
    }
    public void RootingAudio()
    {
        AudioManager.instance.PlaySfx(rootingAudio);
    }
    public void UnRootingAudio()
    {
        AudioManager.instance.PlaySfx(unRootingAudio);
    }
    public void DeadAudio()
    {
        AudioManager.instance.PlaySfx(deadAudio);
    }
}
