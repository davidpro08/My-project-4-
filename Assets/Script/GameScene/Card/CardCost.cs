using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardCost : CardElement
{
    public GameObject background;
    public Sprite[] sprites;
    public GameObject textCost;

    override public void ApplyScript(Card card){
        TextApply(textCost, card.cost);
        BackgroundApply(background, card.type, sprites);
    }

    private void TextApply(GameObject textapply, int cost){
        TextMeshProUGUI text = textapply.GetComponent<TextMeshProUGUI>();
        if(cost<0){
            text.text = "cost error";
        }else{
            text.text = cost.ToString();
        }
    }

    private void BackgroundApply(GameObject backgroundapply, int type, Sprite[] sprites){
        Image image = background.GetComponent<Image>();
        if(type>=1 && type<=5){
            image.sprite = sprites[type];
        }else{
            Debug.Log("타입이 잘못되었습니다.");
            image.sprite = sprites[0];
        }
    }
}
