using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Manages dialog so it can be shown on screen
public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;

    [SerializeField] int lettersPerSecond;

    public static DialogManager Instance { get; private set;}
    private void Awake() {
        Instance = this; 
    }
    public void ShowDialog(Dialog dialog)
    {
        dialogBox.SetActive(true);
        StartCoroutine(TypeDialog(dialog.Lines[0]));
    }

    //pokemon/finalfantasy text animation
    public IEnumerator TypeDialog(string line)
    {
        dialogText.text = "";
        //this adds each letter one by one for the animation
        foreach(var letter in line.ToCharArray())
        {
            dialogText.text += letter; 
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
    }
}
