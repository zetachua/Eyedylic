using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupDialogue : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject dialogueBox;
    public TextMeshProUGUI textComponent;

    public string text;

    public float textSpeed;

    public float exitDelay;
    void Start()
    {
        textComponent.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue()
    {
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        yield return new WaitForSeconds(1);
        foreach(char c in text.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        yield return new WaitForSeconds(exitDelay);
    }

    public void delete()
    {
        Destroy(dialogueBox);
    }
}
