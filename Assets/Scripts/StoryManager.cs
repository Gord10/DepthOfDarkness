using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class StoryManager : MonoBehaviour
{
    public string nextSceneName;
    public string storyFileName;

    public enum StoryType
    {
        INTRO,
        GOOD_ENDING,
        BAD_ENDING
    }

    public StoryType storyType = StoryType.INTRO;

    private TextMeshProUGUI uiText;
    private string[] storyTexts;
    private int counter = 0;

    private void Awake()
    {
        uiText = FindObjectOfType<TextMeshProUGUI>();

        //Read the story from the Resources folder
        TextAsset textAsset = Resources.Load(storyFileName) as TextAsset;
        storyTexts = textAsset.text.Split("\n");
        uiText.text = storyTexts[0];

        switch(storyType)
        {
            case StoryType.INTRO:
                Music.Instance.PlayGameMusic();
                break;

            case StoryType.GOOD_ENDING:
                Music.Instance.PlayGoodEndingMusic();
                break;

            case StoryType.BAD_ENDING:
                Music.Instance.PlayBadEndingMusic();
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Show the next line in the story if it exists. Else, load the next scene
        if(Input.anyKeyDown && Time.timeSinceLevelLoad > 0.2f)
        {
            counter++;
            if(counter >= storyTexts.Length)
            {
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                uiText.text = storyTexts[counter];
            }
        }
    }
}
