using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
public class DialogManager : MonoBehaviour
{
    public CanvasGroup cGroup;
    public TextMeshProUGUI dialogText;

    public float fadeSpeed = 5;

    private List<string> dialogQueue = new List<string>();

    private bool readingMessage = false;

    private void Start()
    {
        cGroup.alpha = 0;
        dialogText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogQueue.Count > 0)
        {
            if (!readingMessage)
            {
                StartCoroutine(nextMessage());
            }
        }
    }

    IEnumerator nextMessage()
    {
        readingMessage = true;
        while(cGroup.alpha > 0)
        {
            cGroup.alpha -= Time.deltaTime * fadeSpeed;
        }
        dialogText.text = dialogQueue[0];
        dialogQueue.RemoveAt(0);
        while(cGroup.alpha < 1)
        {
            cGroup.alpha += Time.deltaTime * fadeSpeed;
        }
        yield return new WaitForSeconds(3);
        while (cGroup.alpha > 0)
        {
            cGroup.alpha -= Time.deltaTime * fadeSpeed;
        }
        readingMessage = false;
    }

    public void AddMessage(string message)
    {
        dialogQueue.Add(message);
    }
}
