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
    void Start()
    {
        TextApply();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TextApply(){
        TextMeshProUGUI text = textEffect.GetComponent<TextMeshProUGUI>();
        if(card.effect==""&&card.effect==(null)){
            text.text = "card null";
        }else{
            text.text = card.effect;
        }
    }
}
