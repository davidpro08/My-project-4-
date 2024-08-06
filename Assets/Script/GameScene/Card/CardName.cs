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
    void Start()
    {
        TextApply();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TextApply(){
        TextMeshProUGUI text = textName.GetComponent<TextMeshProUGUI>();
        if(card.cardname==""&&card.cardname==(null)){
            text.text = "name null";
        }else{
            text.text = card.cardname;
        }
    }
}
