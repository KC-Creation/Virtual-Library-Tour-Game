using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class InteractionReading : MonoBehaviour {

    public string[] WordsOfText;
    public GameObject[] Triggers;
    public float TriggerDistance;
    public string[] TriggerTexts;

    private bool isUIDisplaying;
    private GameObject Player;

    public Text Texts0;
    public GameObject ReadingPanel, HintPanel2;
    FirstPersonController FPC;

	// Use this for initialization
	void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        FPC = Player.GetComponent<FirstPersonController>();
	}

    // Update is called once per frame
    void Update()
    {
        float CloseDistance = 100000f;
        int Subject = 0;

        for (int i = 0; i < Triggers.Length; i++)
        {
            float thisDistance = Vector3.Distance(Triggers[i].transform.position, Player.transform.position);

            if (thisDistance < CloseDistance)
            {
                CloseDistance = thisDistance;
                Subject = i;
            }
        }

        if (CloseDistance < TriggerDistance)
        {
            if (!isUIDisplaying)
            {
                HintPanel2.SetActive(true);

                if (Input.GetKey("e"))
                {
                    ReadingText(Subject);
                    isUIDisplaying = true;
                    EnableMouse(true);
                    HintPanel2.SetActive(false);
                }
            }
        }
        else
        {
            HintPanel2.SetActive(false);

            if (isUIDisplaying)
            {
                ReadingPanel.SetActive(false);
                isUIDisplaying = false;
                EnableMouse(false);
            }
        }
    }

    void ReadingText(int Subject)
    {
        ReadingPanel.SetActive(true);
        string Txt = TriggerTexts[Subject];
        string[] Words = Txt.Split(',');
        int[] intTexts = new int[Words.Length];

        for (int i = 0; i < Words.Length; i++)
        {
            intTexts[i] = int.Parse(Words[i]);
        }

        Texts0.text = WordsOfText[intTexts[0]];
    }

    public void EnableMouse(bool TurnOn)
    {
        if (TurnOn)
        {
            FPC.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            FPC.enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            ReadingPanel.SetActive(false);
        }
    }
            

}
