using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public bool timerState = false;

    public float time = 180f;
    public int timerLimit = 0;

    public TextMeshProUGUI timerText;

    ShopButtons shopAccess;
    BookClicking bookcheck;

    // Start is called before the first frame update
    void Start()
    {
        shopAccess = GameObject.Find("ShopUI").GetComponent<ShopButtons>();
        bookcheck = GameObject.Find("ClickyBook").GetComponent<BookClicking>();
    }

    // Update is called once per frame
    void Update()
    {
        TimerTextChange();

        if (timerState == true)
        {
            time -= Time.deltaTime;
        }
        

        if (time <= timerLimit)
        {
            timerState = false;
            timerText.gameObject.SetActive(false);
            time = 180f;
            shopAccess.HighScoreSave();
            bookcheck.timerActive = false;
            bookcheck.clickAdd = 1;
            shopAccess.ResetShop();
        }
    }

    public void TimerStart()
    {

        if (timerState == false)
        {
            shopAccess.knowledge = 0;
        }
        timerState = true;
        timerText.gameObject.SetActive(true);
        bookcheck.timerActive = true;

    }


    private void TimerTextChange()
    {
        timerText.text = string.Format("Time Left: {00}", Mathf.Floor(time));
    }
}
