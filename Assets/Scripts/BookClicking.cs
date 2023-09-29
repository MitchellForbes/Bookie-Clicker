using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookClicking : MonoBehaviour
{
    Shop addKnowledge;

    public int clickAdd = 1;
    // Start is called before the first frame update
    void Start()
    {
        addKnowledge = GameObject.Find("ShopUI").GetComponent<Shop>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        addKnowledge.knowledge += clickAdd;
        Debug.Log("knowledge added");
    }
}
