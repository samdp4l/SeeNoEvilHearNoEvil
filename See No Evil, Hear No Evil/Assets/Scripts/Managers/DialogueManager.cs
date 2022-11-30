using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    //public GameObject dialogueCanvas;
    public GameObject dialogueBox;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public float textSpeed;
    [HideInInspector]
    public bool playerTalking = true;
    [HideInInspector]
    public bool dialogueActive = false;

    private bool typing = false;
    private Queue<string> playerSentences;
    private Queue<string> demonSentences;
    private GameObject player;
    private GameObject[] enemies;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        //dialogueCanvas.SetActive(false);
        dialogueBox.SetActive(false);
        playerSentences = new Queue<string>();
        demonSentences = new Queue<string>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && typing == false)
        {
            PlayNextSentence();
        }
        if (Input.GetKeyDown(KeyCode.Return) && dialogueActive == true)
        {
            EndDialogue();
        }
    }

    public void PlayDialogue(Dialogue pDialogue, Dialogue dDialogue)
    {
        DisableCharacters();

        dialogueBox.SetActive(true);

        dialogueActive = true;

        playerSentences.Clear();
        demonSentences.Clear();

        foreach (string sentence in pDialogue.sentences)
        {
            playerSentences.Enqueue(sentence);
        }

        foreach (string sentence in dDialogue.sentences)
        {
            demonSentences.Enqueue(sentence);
        }

        PlayNextSentence();
    }

    public void PlayNextSentence()
    {
        if (playerSentences.Count <= 0 && demonSentences.Count <= 0)
        {
            EndDialogue();
            return;
        }

        if (playerTalking)
        {
            string sentence = playerSentences.Dequeue();
            StartCoroutine(TypeSentence(sentence));
            playerTalking = false;
        }
        else 
        {
            string sentence = demonSentences.Dequeue();
            StartCoroutine(TypeSentence(sentence));
            playerTalking = true;
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        typing = true;

        if (playerTalking)
        {
            nameText.text = "Jack Qi";

            dialogueText.text = "";

            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(textSpeed);

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    StopAllCoroutines();
                    typing = false;
                    dialogueText.text = sentence;
                }
            }
        }
        else
        {
            nameText.text = "Demon";

            dialogueText.text = "";

            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(textSpeed);

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    StopAllCoroutines();
                    typing = false;
                    dialogueText.text = sentence;
                }
            }
        }

        typing = false;
    }

    public void EndDialogue()
    {
        StopAllCoroutines();

        dialogueActive = false;
        typing = false;

        dialogueBox.SetActive(false);

        EnableCharacters();
    }

    void DisableCharacters()
    {
        player = GameObject.Find("Player");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        player.GetComponent<DialoguePause>().PauseObject();

        foreach (GameObject e in enemies)
        {
            e.GetComponent<DialoguePause>().PauseObject();
        }
    }

    void EnableCharacters()
    {
        player = GameObject.Find("Player");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        player.GetComponent<DialoguePause>().UnpauseObject();

        foreach (GameObject e in enemies)
        {
            e.GetComponent<DialoguePause>().UnpauseObject();
        }
    }
}
