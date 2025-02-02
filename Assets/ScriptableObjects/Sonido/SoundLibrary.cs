using UnityEngine;

[CreateAssetMenu(fileName = "SoundLibrary", menuName = "Scriptable Objects/Sound Library")]
public class SoundLibrary : ScriptableObject
{
    [System.Serializable]
    public class Sound
    {
        public string name;       
        public AudioClip clip;    
    }

    public Sound[] sounds; 
    public AudioClip GetClip(string soundName)
    {
        foreach (Sound sound in sounds)
        {
            if (sound.name == soundName)
                return sound.clip;
        }
        Debug.LogWarning("Sonido no encontrado: " + soundName);
        return null;
    }
}
