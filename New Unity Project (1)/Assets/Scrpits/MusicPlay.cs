using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlay : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] audioClip;
    private GameObject[] musics;
    
    private void Awake()
    {
        musics = GameObject.FindGameObjectsWithTag("Music");

        if(musics.Length >= 2)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip[SceneManager.GetActiveScene().buildIndex];
        audioSource.Play();
    }

    public void PlayMusic()
    {
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    void Update()
    {
        int Index = SceneManager.GetActiveScene().buildIndex;
        if (Index>0)
        {
            audioSource.clip = audioClip[Index];
            PlayMusic();
        }
    }
}
