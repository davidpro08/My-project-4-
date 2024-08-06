using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardType : MonoBehaviour
{
    public Card card;
    public GameObject background;
    public GameObject textType;
    // Start is called before the first frame update
    void Awake()
    {
        TextApply(textType, card.type);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TextApply(GameObject textapply, int type){
        TextMeshProUGUI temptext = textapply.GetComponent<TextMeshProUGUI>();
        switch(type){
            case 1 : temptext.text = "방어"; break;
            case 2 : temptext.text = "공격"; break;
            case 3 : temptext.text = "특수"; break;
            case 4 : temptext.text = "효과"; break;
            case 5 : temptext.text = "미정"; break;
            default : temptext.text = "타입 오류"; break;
        }
    }
}
