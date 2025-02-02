using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource sfxSource; 
    [SerializeField] private AudioSource musicSource; 
    [SerializeField] private SoundLibrary soundLibrary; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlaySFX(string soundName, float volume = 1.0f)
    {
        AudioClip clip = soundLibrary.GetClip(soundName);
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip, volume);
        }
    }
    public void PlayMusic(string musicName)
    {
        StopMusic();
        AudioClip clip = soundLibrary.GetClip(musicName);
        if (clip != null)
        {
            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.Play();
        }
    }
    public void StopMusic()
    {
        musicSource.Stop();
    }
    public void StopSFX()
    {
        sfxSource.Stop();
    }
}
