using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class logicScript : MonoBehaviour
{
    public TextMeshProUGUI tipText;
    public RectTransform tipWindow;

    public static Action<string, Vector2> OnMouseHover;
    public static Action OnMouseLoseFocus;

    public GameObject tmp;
    string c;
    int x;
    void Start()
    {
        tmp = GameObject.Find("Item 1 Counter");
    }
    public void itemPickUp(string s)
    {
        if (s.Equals("cube"))
        {
            c = tmp.GetComponent<TextMeshProUGUI>().text;
            x = int.Parse(c);
            x++;
            tmp.GetComponent<TextMeshProUGUI>().SetText(x.ToString());
        }
    }

    private void OnEnable()
    {
        OnMouseHover += ShowTip;
        OnMouseLoseFocus += HideTip;
    }
    private void OnDisable()
    {
        OnMouseHover -= ShowTip;
        OnMouseLoseFocus -= HideTip;
    }

    private void ShowTip(String tip, Vector2 mPos)
    {
        tipText.text = tip;
        //tipWindow.sizeDelta = new Vector2(tipText.preferredWidth > 200 ? 200: tipText.preferredWidth,tipText.preferredHeight);
        tipWindow.gameObject.SetActive(true);
        //tipWindow.transform.position = new Vector2(mPos.x, mPos.y);
    }

    private void HideTip()
    {
        tipText.text = default;
        tipWindow.gameObject.SetActive(false);
    }
}
