using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardName : MonoBehaviour
{
    public Card card;
    public GameObject background;
    public GameObject textName;
    // Start is called before the first frame update
    void Awake()
    {
        TextApply(textName, card.cardname);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TextApply(GameObject textapply, string cardname){
        TextMeshProUGUI temptext = textapply.GetComponent<TextMeshProUGUI>();
        if(cardname.Equals("") || cardname.Equals(null)){
            temptext.text = "name error";
        }else{
            temptext.text = cardname;
        }
    }
}
