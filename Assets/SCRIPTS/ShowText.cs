using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    public TextMeshProUGUI text;
    
    // Start is called before the first frame update
    void Start()
    {
        HidePopupText();
    
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
    void ShowPopupText(){
        text.gameObject.SetActive(true);
    }
    void HidePopupText(){
        text.gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")) ShowPopupText();
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")) HidePopupText();
    }
}
