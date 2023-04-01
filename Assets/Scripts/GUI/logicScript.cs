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
    public GameObject player;
    public GameObject cameraController;
    private TextMeshProUGUI Currency;

    public static Action<string, Vector2> OnMouseHover;
    public static Action OnMouseLoseFocus;

    void Start()
    {
        Currency = GameObject.Find("Currency Counter").GetComponent<TextMeshProUGUI>();
    }

    public void itemPickUp(string itemName)
    {
        var c = Currency.text;
        int x = int.Parse(c);
        x++;
        Currency.SetText(x.ToString());
    }

    /*public void itemPickUp(string s,Component)
    {
        if (s.Equals("Riyal"))
        {
            c = tmp.GetComponent<TextMeshProUGUI>().text;
            x = int.Parse(c);
            x++;
            tmp.GetComponent<TextMeshProUGUI>().SetText(x.ToString());
        }
    }*/

    /*public void itemPickUp(string name, Func<TextMeshProUGUI> getComponent)
    {
        if (name.Equals("Riyal"))
        {
            c = GetComponent.;
            x = int.Parse(c);
            x++;
            tmp.GetComponent<TextMeshProUGUI>().SetText(x.ToString());
        }
    }*/

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

    public void Pause()
    {
        Time.timeScale = 0;
        cameraController.GetComponent<CameraController>().enabled = false;

        /*cameraController.enabled = cameraController.enabled ? false : true;
        Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;
        keybindMenu.alpha = keybindMenu.alpha > 0 ? 0 : 1;
        keybindMenu.blocksRaycasts = keybindMenu.blocksRaycasts ? false : true;
        Time.timeScale = Time.timeScale > 0 ? 0 : 1;*/
    }

    public void Resume()
    {
        Time.timeScale = 1;
        cameraController.GetComponent<CameraController>().enabled = true;
    }

    public string getHP()
    {
        int hp = player.GetComponent<Player>().health;
        return hp.ToString();
    }

    /*public string getShield()
    {
        int hp = player.GetComponent<Player>().
        return hp.ToString();
    }*/

    public string getFuel()
    {
        float fuel = player.GetComponent<SpeedBoost>().currentFuel;
        return fuel.ToString();
    }

    /*public string getArmor()
    {
        int hp = player.GetComponent<Player>().health;
        return hp.ToString();
    }*/

    /*public string getTopSpeed()
    {
        int hp = player.GetComponent<Player>().
        return hp.ToString();
    }*/

    public string getAcc()
    {
        float acc = player.GetComponent<WheelController>().acceleration;
        acc = acc / 100;
        return acc.ToString();
    }

    public string getMaxJumps()
    {
        int jumps = player.GetComponent<JumpController>().maxNumberOfJumps;
        return jumps.ToString();
    }
}
