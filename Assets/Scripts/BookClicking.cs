using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookClicking : MonoBehaviour
{
    ShopButtons addKnowledge;
    Renderer bookColour;

    public int clickAdd = 1;
    // Start is called before the first frame update
    void Start()
    {
        addKnowledge = GameObject.Find("ShopUI").GetComponent<ShopButtons>();
        bookColour = GetComponent<Renderer>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        addKnowledge.knowledge += clickAdd;
        Debug.Log("knowledge added");

        bookColour.material.color = Color.red;
        StartCoroutine(SetColourBack());
    }

    private IEnumerator SetColourBack()
    {
        yield return new WaitForSeconds(0.1f);
        bookColour.material.color = Color.white;
    }
}
