using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardEffect : CardElement
{
    public Card card;
    public GameObject background;
    public GameObject textEffect;


    override public void ApplyScript(Card card){
        TextApply(textEffect, card.effect);
    }

    private void TextApply(GameObject textapply, string effect){
        TextMeshProUGUI temptext = textapply.GetComponent<TextMeshProUGUI>();
        if(effect.Equals("") || effect.Equals(null)){
            temptext.text = "effect error";
        }else{
            temptext.text = effect;
        }
    }
}
