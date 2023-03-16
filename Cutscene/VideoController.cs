using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    [SerializeField] UnityEngine.Video.VideoPlayer video;
    [SerializeField] private bool nextscene = true;
    [SerializeField] private GameObject[] toDisable;
    [SerializeField] private GameObject black;
    private int k = 0;
    private void Start()
    {
        foreach (GameObject obj in toDisable)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
        if(black != null)
        {
            black.SetActive(false);
        }
        
    }
    void Update()
    {
        if(video.isPlaying == false)
        {
            k++;
        }
        if(k == 15)
        {
            
            if (nextscene)
            {
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                video.enabled = false;
                gameObject.SetActive(false);
                foreach (GameObject obj in toDisable)
                {
                    if (obj != null)
                    {
                        obj.SetActive(true);
                    }
                }
            }
        }
    }
}
