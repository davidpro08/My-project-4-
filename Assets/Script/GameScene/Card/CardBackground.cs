using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardBackground : CardElement
{
    public Card card;
    public GameObject background;
    public Sprite[] sprites;
    // Start is called before the first frame update
    override public void ApplyScript(Card card){
        BackgroundApply(background, card.character, sprites);
    }

    private void BackgroundApply(GameObject backgroundapply, int character, Sprite[] sprites){
        Image image = backgroundapply.GetComponent<Image>();
        if(character>=1 && character<=5){
            image.sprite = sprites[character];
        }else{
            Debug.Log("타입이 잘못되었습니다.");
            Debug.Log(character);
            image.sprite = sprites[0];
        }
    }
}
