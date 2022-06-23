using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public GameObject backgroundImage;
    public GameObject panelPauseMenu;

    Animator panelPauseMenuAnimator;

    public AudioSource audio;
    public AudioClip clip;

    public AudioSource backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        panelPauseMenuAnimator = panelPauseMenu.GetComponent<Animator>();
        backgroundImage.SetActive(true);
        panelPauseMenuAnimator.SetBool("Slide", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume()
    {
        backgroundImage.SetActive(true);
        panelPauseMenuAnimator.SetBool("Slide", false);
    }

    public void PlayClickSound()
    {
        audio.PlayOneShot(clip);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
         StartCoroutine(WaitAndPlay());
    }

    IEnumerator WaitAndPlay()
    {
        while (true)
        {
            yield return new WaitForSeconds(.1f);
            backgroundMusic.volume = 0.8f;
            yield return new WaitForSeconds(.1f);
            backgroundMusic.volume = 0.6f;
            yield return new WaitForSeconds(.1f);
            backgroundMusic.volume = 0.4f;
            yield return new WaitForSeconds(.1f);
            backgroundMusic.volume = 0.2f;
            yield return new WaitForSeconds(.1f);
            backgroundMusic.volume = 0.0f;

            PlayerPrefs.SetString("LoadScene", "MainMenu");
            SceneManager.LoadScene("LoadingScene");
        }
    }
}
