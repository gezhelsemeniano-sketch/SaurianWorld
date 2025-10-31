using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clips")]
    public AudioClip IntroMenu;
    public AudioClip Clicks;

    private void Start()
    {
        musicSource.clip = IntroMenu;
        musicSource.Play();
    }
    public void PLayerSFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}

