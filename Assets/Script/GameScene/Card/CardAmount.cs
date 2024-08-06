using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardAmount : MonoBehaviour
{
    public Card card;
    public GameObject background;
    public Sprite[] sprites;
    public GameObject textAmount;
    // Start is called before the first frame update
    void Awake()
    {
        TextApply(textAmount, card.amount);
        BackgroundApply(background, card.type, sprites);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TextApply(GameObject textapply, int amount){
        TextMeshProUGUI temptext = textapply.GetComponent<TextMeshProUGUI>();
        if(amount<0){
            temptext.text = "amount error";
        }else{
            temptext.text = amount.ToString();
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
