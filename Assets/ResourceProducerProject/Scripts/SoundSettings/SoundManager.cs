using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private SoundSettings _settings;
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _effectsSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            LoadSettings();
            InitializeAudioSources();
            PlayBackgroundMusic();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeAudioSources()
    {
        _musicSource.volume = _settings.musicVolume;
        _effectsSource.volume = _settings.effectsVolume;
        _musicSource.mute = _settings.isMuted;
        _effectsSource.mute = _settings.isMuted;
    }

    public void PlayBackgroundMusic()
    {
        if (_settings.backgroundMusic != null)
        {
            _musicSource.clip = _settings.backgroundMusic;
            _musicSource.loop = true;
            _musicSource.Play();
        }
    }

    public void PlayEffect( )
    {
        _effectsSource.Play();
    }

    public void ToggleMute()
    {
        _settings.isMuted = !_settings.isMuted;
        ApplyMuteSettings();
        SaveSettings();
    }

    private void ApplyMuteSettings()
    {
        _musicSource.mute = _settings.isMuted;
        _effectsSource.mute = _settings.isMuted;
    }

    public void SetMusicVolume(float volume)
    {
        _settings.musicVolume = volume;
        _musicSource.volume = volume;
        SaveSettings();
    }

    public void SetEffectsVolume(float volume)
    {
        _settings.effectsVolume = volume;
        _effectsSource.volume = volume;
        SaveSettings();
    }

    private void SaveSettings()
    {
        PlayerPrefs.SetString("SoundSettings", JsonUtility.ToJson(_settings));
    }

    private void LoadSettings()
    {
        if (PlayerPrefs.HasKey("SoundSettings"))
        {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("SoundSettings"), _settings);
        }
    }
}