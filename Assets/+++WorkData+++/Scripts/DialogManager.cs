using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.InputSystem;
using UnityEditor.Rendering;
using UnityEditor.Experimental.GraphView;
public class DialogManager : MonoBehaviour
{
    [SerializeField] private TextAsset inkAsset;
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private TMP_Text dialogText;
    [SerializeField] private TMP_Text speakerText;
    [SerializeField] private GameObject ChoiceOneButton;
    [SerializeField] private GameObject ChoiceTwoButton;
    [SerializeField] private GameObject ChoiceThreeButton;
    [SerializeField] private TMP_Text ChoiceOneText;
    [SerializeField] private TMP_Text ChoiceTwoText;
    [SerializeField] private TMP_Text ChoiceThreeText;

    private Story inkStory;

    private void Awake()
    {
        inkStory = new Story(inkAsset.text);
    }
    private void Start()
    {
        
        dialogBox.SetActive(false);
        
    }
    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            InkyContinue();
        }
    }
    public void InkyContinue()
        {
            if (inkStory.canContinue &&dialogBox.activeSelf == true)
            {
                dialogText.text = inkStory.Continue();
            if (inkStory.currentTags.Count > 0)
            {
                foreach (string currentTag in inkStory.currentTags) 
                {
                    speakerText.text = currentTag + " is speaking";
                }
            }
            }

            if(inkStory.currentChoices.Count > 0)
        {
            ChoiceOneButton.SetActive(true);
            ChoiceTwoButton.SetActive(true);
            ChoiceThreeButton.SetActive(true);
            for (int i = 0; i < inkStory.currentChoices.Count; i++)
            {
                Choice currentChoice = inkStory.currentChoices[i];
                if (i == 0)
                {
                    ChoiceOneText.text = currentChoice.text;
                }
                if (i ==1)
                {
                    ChoiceTwoText.text = currentChoice.text;
                }
                if (i == 2)
                {
                    ChoiceThreeText.text = currentChoice.text;
                }
            }
           
        }
        else
        {
            ChoiceOneButton.SetActive(false);
            ChoiceTwoButton.SetActive(false);
            ChoiceThreeButton.SetActive(false);
        }


    }
        void selectInkChoice(int choiceIndex)
        {
            if(inkStory.currentChoices.Count > 0)
            {
                inkStory.ChooseChoiceIndex(choiceIndex);
                InkyContinue();
            }
        }
    public void ChoiceOne()
    {
        selectInkChoice(0);
    }
    public void ChoiceTwo()
    {
        selectInkChoice(1);
    }
    public void ChoiceThree()
    {
        selectInkChoice(2);
    }

}
