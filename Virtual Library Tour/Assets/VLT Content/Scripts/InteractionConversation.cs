using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class InteractionConversation : MonoBehaviour {

    public string[] Questions, Answers; // An empty array that stores strings of Questions and Answers.
    public GameObject[] Triggers; // An empty array that stores GameObjects of Triggers.
    public float TriggerDistance; // A float value of TriggerDistance.
    public string[] TriggerQuestions; // Write as string with commas seperating in the Inspector.

    private bool isUIDisplaying; // A true and false statement to check if the UI is display or not.
    private GameObject Closet;
    private GameObject Player; // Creates a GameObject named "Player".

    public Text Question0, Question1, Question2, Reply;
    private int Answer0, Answer1, Answer2;
    public GameObject QuestionPanel, AnswerPanel, HintPanel;
    FirstPersonController FPC; // FPC = First Person Controller.

    // Use this for initialization
    void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); // When the game starts, this will find an object that is tag Player.
        FPC = Player.GetComponent<FirstPersonController>(); // RFPC refers to the Player's rigidbody.
	}
	
	// Update is called once per frame
	void Update ()
    {
        float CloseDistance = 100000f;
        int Subject = 0;

        for (int i = 0; i < Triggers.Length; i++) // i = Counter.
        {
            float thisDistance = Vector3.Distance(Triggers[i].transform.position, Player.transform.position);
            // If current distance is less that close distance, then close distance will be the new current distance.
            if (thisDistance < CloseDistance)
            {
                CloseDistance = thisDistance;
                Subject = i;
            }
        }
        // Checks if the Player enters the close distance of the Trigger box.
        if (CloseDistance < TriggerDistance)
        {
            if (!isUIDisplaying)
            {
                HintPanel.SetActive(true); // If the Player enters this TriggerDistance, then activate Hint Panel from Unity.

                if (Input.GetKey("e"))
                {
                    QsAs(Subject); // Call the functions.
                    isUIDisplaying = true; // Calls the boolean.
                    EnableMouse(true); // Enable the mouse.
                    HintPanel.SetActive(false); // Disable the Hint Panel when the Player presses E.
                }
            }
        }
        // Otherwise, checks if the Player left the close distance.
        else
        {
            HintPanel.SetActive(false);

            if (isUIDisplaying)
            {
                QuestionPanel.SetActive(false);
                AnswerPanel.SetActive(false);
                isUIDisplaying = false;
                EnableMouse(false);
            }
        }
	}

    void QsAs(int Subject)
    {
        print(Subject);
        QuestionPanel.SetActive(true);
        string Qs = TriggerQuestions[Subject];
        string[] QuestionAnswer = Qs.Split(',');
        int[] intQuestion = new int[QuestionAnswer.Length];

        for(int i = 0; i < QuestionAnswer.Length; i++)
        {
            intQuestion[i] = int.Parse(QuestionAnswer[i]);
        }

        Question0.text = Questions[intQuestion[0]];
        Question1.text = Questions[intQuestion[1]];
        Question2.text = Questions[intQuestion[2]];
        Answer0 = intQuestion[0];
        Answer1 = intQuestion[1];
        Answer2 = intQuestion[2];
    }

    public void As(int Rep)
    {
        QuestionPanel.SetActive(false);
        AnswerPanel.SetActive(true);
        switch (Rep)
        {
            case 0:
                Reply.text = Answers[Answer0];
                break;
            case 1:
                Reply.text = Answers[Answer1];
                break;
            case 2:
                Reply.text = Answers[Answer2];
                break;
        }
    }

    public void GoBack(int X)
    {
        QuestionPanel.SetActive(true);
        AnswerPanel.SetActive(false);
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
            QuestionPanel.SetActive(false);
            AnswerPanel.SetActive(false);
        }
    }
}
