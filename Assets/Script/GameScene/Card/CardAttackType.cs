using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardAttacktype : MonoBehaviour
{
    public Card card;
    public GameObject background;
    public GameObject attackType;

    public Sprite[] backgroundsprite;
    public Sprite[] attacktypesprite;
    // Start is called before the first frame update
    void Awake()
    {
        BackgroundApply(background, card.type, backgroundsprite);
        BackgroundApply(attackType, card.attackType, attacktypesprite);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void BackgroundApply(GameObject backgroundapply, int type, Sprite[] sprites){
        Image image = backgroundapply.GetComponent<Image>();
        if(type>=1 && type<=5){
            image.sprite = sprites[type];
        }else{
            Debug.Log("타입이 잘못되었습니다.");
            image.sprite = sprites[0];
        }
    }
}
