using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuControl : MonoBehaviour
{
    public GameObject panelMainMenu;
    public GameObject panelSettingsMenu;
    public GameObject audioMenu;

    public AudioSource audio;
    public AudioClip clip;

    public AudioSource backgroundMusic;

    Animator mainMenuAnimator;
    Animator settingsMenuAnimator;
    Animator audioMenuAnimator;



    // Start is called before the first frame update
    void Start()
    {
        mainMenuAnimator = panelMainMenu.GetComponent<Animator>();
        settingsMenuAnimator = panelSettingsMenu.GetComponent<Animator>();
        audioMenuAnimator =  audioMenu.GetComponent<Animator>();

        mainMenuAnimator.SetBool("Slide",false);
        settingsMenuAnimator.SetBool("Slide",true);
        audioMenuAnimator.SetBool("Slide",true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSettingsMenu()
    {
        mainMenuAnimator.SetBool("Slide", true);
        settingsMenuAnimator.SetBool("Slide", false);
        audioMenuAnimator.SetBool("Slide",true);
    }

    public void UnLoadSettingsMenu()
    {
        mainMenuAnimator.SetBool("Slide",false);
        settingsMenuAnimator.SetBool("Slide",true);
        audioMenuAnimator.SetBool("Slide",true);
    }

    public void Play()
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

            PlayerPrefs.SetString("LoadScene", "Scene-1");
            SceneManager.LoadScene("LoadingScene");
        }
    }

    public void PlayClickSound()
    {
        audio.PlayOneShot(clip);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SetVolume()
    {
        mainMenuAnimator.SetBool("Slide", true);
        settingsMenuAnimator.SetBool("Slide",true);
        audioMenuAnimator.SetBool("Slide", false);
    }

   
}
