using UnityEngine;

[CreateAssetMenu(menuName = "Configs/SoundSettings")]
public class SoundSettings : ScriptableObject
{
    public AudioClip backgroundMusic;
    public AudioClip popupSound;
    
    [Range(0f, 1f)] public float musicVolume = 1f;
    [Range(0f, 1f)] public float effectsVolume = 1f;
    public bool isMuted;
}