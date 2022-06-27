using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneLoadr : MonoBehaviour
{
    public Slider slider;
    public TMP_Text text;
    string scene;

    void Awake()
    {
        scene = PlayerPrefs.GetString("LoadScene");
    }

    // Start is called before the first frame update
    void Start()
    {
         if(scene != null)
         {
            StartCoroutine(LoadScene());
         }
         else
         {
            Debug.Log("Scene == null");
         }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

     

    IEnumerator LoadScene()
    {
        yield return null;

        //Begin to load the Scene you specify
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene);
        //Don't let the Scene activate until you allow it to
        //asyncOperation.allowSceneActivation = false;
        //Debug.Log("Pro :" + asyncOperation.progress);
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            //m_Text.text = "Loading progress: " + (asyncOperation.progress * 100) + "%";

            // Check if the load has finished
            // if (asyncOperation.progress >= 0.9f)
            // {
            //     //Change the Text to show the Scene is ready
            //     //m_Text.text = "Press the space bar to continue";
            //     //Wait to you press the space key to activate the Scene
            //     //if (Input.GetKeyDown(KeyCode.Space))
            //         //Activate the Scene
            //         //asyncOperation.allowSceneActivation = true;
            // }

            slider.value = asyncOperation.progress;

            yield return null;
        }
    }
}
