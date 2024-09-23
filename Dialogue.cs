using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    public GameObject DialogueBox;

    public void OpenDialogueBox()
    {
        DialogueBox.SetActive(true);
        TryGetComponent(out Dialogue dialogue);
        dialogue.StartDialogue();

    }
}
public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;

    public string[] lines;

    private float textSpeed;

    private int index;


    private void Start()
    {
        StartDialogue();
    }

    private void Update()
    {
        textSpeed = 0.1f;
        textComponent.text = string.Empty;

        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            } else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine()); 
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        } else
        {
            gameObject.SetActive(false);
        }

    }
}
