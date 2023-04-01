using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class itemTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string tip;
    private float timeToWait = 0.5f;
    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(StartTimer());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        logicScript.OnMouseLoseFocus();
    }

    private void ShowMessage()
    {
        logicScript.OnMouseHover(tip,Input.mousePosition);
    }
    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(timeToWait);

        ShowMessage();
    }
}
