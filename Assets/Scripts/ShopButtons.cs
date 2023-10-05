using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopButtons : MonoBehaviour
{
    BookClicking bookCheck;
    public int knowledge;

    public int passKnowledge;

    private int priceItemOne;
    private int priceItemTwo;
    private int priceItemThree;
    private int priceItemFour;
    private int priceItemFive;
    private int priceItemSix;
    private int priceItemSeven;
    private int priceItemEight;

    private bool Itemcheck;
    private bool passCheck;

    [SerializeField] TextMeshProUGUI knowledgeUI;
    [SerializeField] TextMeshProUGUI itemOneUI;
    [SerializeField] TextMeshProUGUI itemTwoUI;
    [SerializeField] TextMeshProUGUI itemThreeUI;
    [SerializeField] TextMeshProUGUI itemFourUI;
    [SerializeField] TextMeshProUGUI itemFiveUI;
    [SerializeField] TextMeshProUGUI itemSixUI;
    [SerializeField] TextMeshProUGUI itemSevenUI;
    [SerializeField] TextMeshProUGUI itemEightUI;

    [SerializeField] TextMeshProUGUI highScoreText;

    [SerializeField] TextMeshProUGUI shopInfo;

    public int highScore;

    // Start is called before the first frame update
    void Start()
    {
        bookCheck = GameObject.Find("ClickyBook").GetComponent<BookClicking>();
        //passKnowledge = 1f;
        StartCoroutine("TimeCheck");
        priceItemOne = 10;
        priceItemTwo = 20;
        priceItemThree = 50;
        priceItemFour = 50;
        priceItemFive = 100;
        priceItemSix = 100;
        priceItemSeven = 5000;
        priceItemEight = 5000;

        Itemcheck = false;
        passCheck = false;

        LoadHighScore();
    }

    private void Update()
    {
        ShopUI();
    }

    public void ButtonCheck()
    {
        Debug.Log("buttonCheck");
        knowledge -= 1;
    }

    public void ClickyBookAdd()
    {
        if (priceItemOne <= knowledge)
        {
            bookCheck.clickAdd += 1;
            knowledge = knowledge - priceItemOne;
            priceItemOne = priceItemOne * 2 - 5;
        }
    }

    public void ItemTwo()
    {
        if(priceItemTwo <= knowledge)
        {
            passKnowledge += 1;
            knowledge -= priceItemTwo;
            priceItemTwo = priceItemTwo * 2 - 5;
        }
    }

    public void ItemThree()
    {
        if(priceItemThree <= knowledge)
        {
            bookCheck.clickAdd += 2;
            knowledge -= priceItemThree;
            priceItemThree = priceItemThree * 2 - 5;
        }
        
    }

    public void ItemFour()
    {
        if (priceItemFour <= knowledge)
        {
            passKnowledge += 2;
            knowledge -= priceItemFour;
            priceItemFour = priceItemFour * 2 - 5;
        }
    }

    public void ItemFive()
    {
        if (priceItemFive <= knowledge)
        {
            bookCheck.clickAdd += 3;

            knowledge -= priceItemFive;
            priceItemFive = priceItemFive * 2 - 5;
        }
    }

    public void ItemSix()
    {
        if (priceItemSix <= knowledge)
        {
            passKnowledge += 3;

            knowledge -= priceItemSix;
            priceItemSix = priceItemSix * 2 - 5;
        }
    }

    public void ItemSeven()
    {
        if (Itemcheck == false && priceItemSeven <= knowledge)
        {
            bookCheck.clickAdd *= 2;
            Itemcheck = true;
            knowledge -= priceItemSeven;
        }
    }

    public void ItemEight()
    {
        if (passCheck == false && priceItemEight <= knowledge)
        {
            passKnowledge *= 2;
            passCheck = true;
            knowledge -= priceItemEight;


        }
    }

    void ShopUI()
    {
        knowledgeUI.text = $"Knowledge: {knowledge}";
        itemOneUI.text = $"Reading Glasses: {priceItemOne}";
        itemTwoUI.text = $"Read Aloud: {priceItemTwo}";
        itemThreeUI.text = $"BookMark: {priceItemThree}";
        itemFourUI.text = $"Teacher: {priceItemFour}";
        itemFiveUI.text = $"Book Light: {priceItemFive}";
        itemSixUI.text = $"Book of Potatos: {priceItemSix}";
        itemSevenUI.text = $"Kindle: {priceItemSeven}";
        itemEightUI.text = $"Another Book: {priceItemEight}";

        highScoreText.text = $"HighScore: {highScore}";

    }


    public void HighScoreSave()
    {

        if(highScore <= knowledge)
        {
            highScore = knowledge;

            SaveHighScore();
        }

        
    }


    public void ShopInfomation()
    {
        if (shopInfo.gameObject.activeInHierarchy == true)
        {
            shopInfo.gameObject.SetActive(false);
            Debug.Log("Text Not active");
        }

        else if (shopInfo.gameObject.activeInHierarchy == false)
        {
            shopInfo.gameObject.SetActive(true);
            Debug.Log("Text active");
        }
    }



    public void ResetShop()
    {
        knowledge = 0;
        passKnowledge = 0;
        priceItemOne = 10;
        priceItemTwo = 20;
        priceItemThree = 50;
        priceItemFour = 50;
        priceItemFive = 100;
        priceItemSix = 100;
        priceItemSeven = 5000;
        priceItemEight = 5000;

        Itemcheck = false;
        passCheck = false;
    }

    IEnumerator TimeCheck()
    {
        for (; ; )
        {
            knowledge += passKnowledge;
            yield return new WaitForSeconds(.2f);
        }
    }


    void SaveHighScore()
    {
        PlayerPrefs.SetInt("SavedHighScore", highScore);
        Debug.Log("Score saved " + highScore);

    }

    void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("SavedHighScore");
        Debug.Log("Score Loaded " + highScore);
    }



}
