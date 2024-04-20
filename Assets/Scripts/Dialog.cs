using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{

    public TextMeshProUGUI dialogText;

    public string[] firstDialog;
    public string[] secondDialog;
    public string[] thirdDialog;

    public float textSpeed;
    private int index;  

    void Start()
    {
        dialogText.text = string.Empty;

        StartDialoge();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(dialogText.text == firstDialog[index])
            {
                NextLine();
            }

            else
            {
                StopAllCoroutines();
                dialogText.text = firstDialog[index];
                
            }
        }
    }


    void StartDialoge()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in firstDialog[index].ToCharArray())
        {
            dialogText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if(index < firstDialog.Length -1)
        {
            index++;
            dialogText.text = string.Empty;
            StartCoroutine (TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void ResetDialog()
    {
        index = 0;
    }
}

