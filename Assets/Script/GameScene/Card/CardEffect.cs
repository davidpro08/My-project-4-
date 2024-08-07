using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardEffect : MonoBehaviour
{
    public Card card;
    public GameObject background;
    public GameObject textEffect;
    // Start is called before the first frame update
    void Awake()
    {
        TextApply(textEffect, card.effect);
    }

    // Update is called once per frame
    void Update()
    {
        
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
