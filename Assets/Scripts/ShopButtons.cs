using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButtons : MonoBehaviour
{
    BookClicking bookCheck;
    public int knowledge;


    public int priceItemOne;
    // Start is called before the first frame update
    void Start()
    {
        bookCheck = GameObject.Find("ClickyBook").GetComponent<BookClicking>();

        priceItemOne = 10;
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

    }

    public void ItemThree()
    {

    }

    public void ItemFour()
    {

    }

    public void ItemFive()
    {

    }
}
