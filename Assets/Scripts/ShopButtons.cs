using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButtons : MonoBehaviour
{
    BookClicking bookCheck;
    public float knowledge;

    public float passKnowledge;

    public int priceItemOne;
    public int priceItemTwo;
    public int priceItemThree;
    public int priceItemFour;

    private bool Itemcheck;

    // Start is called before the first frame update
    void Start()
    {
        bookCheck = GameObject.Find("ClickyBook").GetComponent<BookClicking>();
        //passKnowledge = 1f;
        StartCoroutine("TimeCheck");
        priceItemOne = 10;
        priceItemTwo = 20;
        priceItemThree = 50;
        priceItemFour = 1000;

        Itemcheck = false;
    }

    private void Update()
    {
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
            priceItemOne = priceItemOne * 2 + 5;
        }
    }

    public void ItemTwo()
    {
        if(priceItemFour <= knowledge)
        {
            passKnowledge += 1f;
            knowledge -= priceItemTwo;
        }
    }

    public void ItemThree()
    {
        if(priceItemThree <= knowledge)
        {
            passKnowledge += 2f;
            knowledge -= priceItemThree;
        }
        
    }

    public void ItemFour()
    {
        if (Itemcheck == false && priceItemFour <= knowledge)
        {
            bookCheck.clickAdd *= 2;
            Itemcheck = true;
            knowledge -= priceItemFour;
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

    //public void ItemFive()
    //{

    //}
}
