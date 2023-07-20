using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame 
    int sum1, sum2;

    [SerializeField]
    TMP_Text operationText;

    [SerializeField]
    TMP_Text option1Text;

    [SerializeField]
    TMP_Text option2Text;

    [SerializeField]
    TMP_Text option3Text;

    [SerializeField]
    GameObject WinPanel;

    [SerializeField]
    GameObject LosePanel;

    int result;
    int randNum1;
    int randNum2;

    void Start() {
        WinPanel.gameObject.SetActive(false);
        LosePanel.gameObject.SetActive(false);

        sum1 = Random.Range(1, 15);
        sum2 = Random.Range(1, 15);

        randNum1 = Random.Range(0, 50);
        randNum2 = Random.Range(0, 50);
        result = sum1 + sum2;

        operationText.text = $"{sum1} + {sum2}";

        // Check if any rand num is equal to result and change it
        if (randNum1 == result)
        {
            randNum1++;
        }

        if (randNum2 == result)
        {
            randNum2++;
        }

        string[] optionsTextArray = new string[] { option1Text.text, option2Text.text, option3Text.text };

        int randIndex = Random.Range(0, 3);
        int secondIndex = (randIndex + 1) % 3;
        int thirdIndex = (randIndex + 2) % 3;

        optionsTextArray[randIndex] = result.ToString();
        optionsTextArray[secondIndex] = randNum1.ToString();
        optionsTextArray[thirdIndex] = randNum2.ToString();


        //option1Text.text = randNum1.ToString();
        //option2Text.text = randNum2.ToString();
        //option3Text.text = result.ToString();

        option1Text.text = optionsTextArray[0];
        option2Text.text = optionsTextArray[1];
        option3Text.text = optionsTextArray[2];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClickButton(TMP_Text option)
    {
        if (option.text == result.ToString())
        {
            winGame();
        } else
        {
            loseGame();
        }
    }


    public void winGame()
    {
        WinPanel.gameObject.SetActive(true);
    }


    public void loseGame()
    {
        LosePanel.gameObject.SetActive(true);
    }

    public void resetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
        
    
}
