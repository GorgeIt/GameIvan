using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class DialogueStart : MonoBehaviour
{
    private GameObject player;

    [SerializeField] private GameObject SpawnObj;
    [SerializeField] private GameObject EText;
    [SerializeField] private Sprite icon;
    [SerializeField] private Image npcIcon;
    [SerializeField] private GameObject DialogCamera;
    [SerializeField] private GameObject playerVisual;
    [SerializeField] private GameObject CameraM;
    [SerializeField] private GameObject[] toDisable;

    [SerializeField] UnityEvent m_OnInteraction;


    private bool flag = true;

    void Start()
    {
        player = GameObject.Find("Player");
    }
    
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        //Interact
        if (distanceToPlayer <= 4)
        {
            if (flag)EText.SetActive(true);
            if (Input.GetButtonDown("E") && flag)
            {
                EnableDialog();
                
            }
            /*else if (Input.GetButtonDown("E") && !flag)
            {
                DisableDialog();
            }*/
        }
        else
        {
            EText.SetActive(false);
        }

    }
    public void DoInteraction()
    {
        m_OnInteraction.Invoke();
    }
    void EnableDialog()
    {
        foreach (GameObject obj in toDisable)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
        npcIcon.sprite = icon;
        SpawnObj.SetActive(true);
        CameraM.SetActive(false);
        DialogCamera.SetActive(true);
        player.SetActive(false);
        playerVisual.SetActive(true);
        flag = false;
        DoInteraction();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        EText.SetActive(false);
    }
    public void DisableDialog()
    {
        foreach (GameObject obj in toDisable)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
        CameraM.SetActive(true);
        SpawnObj.SetActive(false);
        flag = true;
        player.SetActive(true);
        DialogCamera.SetActive(false);
        playerVisual.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
