using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public GameObject dialoguePanel;
    public TMP_Text dialogueText;

    private string[] lines;
    private int currentLine;

    private bool isTalking = false;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (!isTalking)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextLine();
        }
    }

    public void StartDialogue(string[] dialogueLines)
    {
        lines = dialogueLines;

        currentLine = 0;

        isTalking = true;

        dialoguePanel.SetActive(true);

        dialogueText.text = lines[currentLine];
    }

    void NextLine()
    {
        currentLine++;

        if (currentLine >= lines.Length)
        {
            EndDialogue();
            return;
        }

        dialogueText.text = lines[currentLine];
    }

    void EndDialogue()
    {
        isTalking = false;

        dialoguePanel.SetActive(false);
    }

    public bool IsTalking()
    {
        return isTalking;
    }
}