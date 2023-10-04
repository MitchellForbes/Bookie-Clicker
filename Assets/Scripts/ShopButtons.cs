using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopButtons : MonoBehaviour
{
    BookClicking bookCheck;
    public float knowledge;

    public float passKnowledge;

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

    [SerializeField] TextMeshProUGUI shopInfo;



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
            passKnowledge += 1f;
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
            passKnowledge += 2f;
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
            passKnowledge += 3f;

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
        itemTwoUI.text = $"Item 2: {priceItemTwo}";
        itemThreeUI.text = $"Item 3: {priceItemThree}";
        itemFourUI.text = $"Item 4: {priceItemFour}";
        itemFiveUI.text = $"Item 5: {priceItemFive}";
        itemSixUI.text = $"Item 6: {priceItemSix}";
        itemSevenUI.text = $"Item 7: {priceItemSeven}";
        itemEightUI.text = $"item 8: {priceItemEight}";
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

    IEnumerator TimeCheck()
    {
        for (; ; )
        {
            knowledge += passKnowledge;
            yield return new WaitForSeconds(.2f);
        }
    }

}
