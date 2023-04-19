using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class multiPurchaseScript : MonoBehaviour, IPointerClickHandler
{
    public vendorLogic logic;
    public GameObject price;
    public GameObject counter;
    public GameObject panel;
    private TextMeshProUGUI currentCounter;
    public bool isItem;
    int itemCount;
    int itemPrice;
    void Start()
    {
        logic = GameObject.Find("Vendor Canvas").GetComponent<vendorLogic>();
        currentCounter = counter.GetComponent<TextMeshProUGUI>();
        itemPrice = int.Parse(price.GetComponent<TextMeshProUGUI>().text);
    }

    
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        bool b=logic.purchase(itemPrice);
        if (b)
        {
            if (isItem) { 
            itemCount = int.Parse(currentCounter.text);
            itemCount++;
            currentCounter.text=itemCount.ToString();
            }
            else
            {
                itemCount = int.Parse(currentCounter.text);
                itemCount--;
                currentCounter.text = itemCount.ToString();
                if (itemCount == 0)
                    panel.SetActive(false);
            }
        }
    }
}
