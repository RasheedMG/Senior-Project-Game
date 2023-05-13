using System.Collections;
using UnityEngine;

public class ExtendBridgeLever : Lever
{
    [SerializeField] private Transform bridgeTransform;
    [SerializeField] private float bridgeExtensionOffset;
    [SerializeField] private float extensionTime = 1f;  // Time it takes for the bridge to extend
    [SerializeField] private float retractionDelay = 5f;  // Time before the bridge starts retracting

    public override void Interact()
    {
        if (!playerIsWithinRange)
            return;
        StartCoroutine(ExtendAndRetractBridge());
    }

    private IEnumerator ExtendAndRetractBridge()
    {
        // Extension
        yield return StartCoroutine(ExtendBridge());

        // Delay before retraction
        yield return new WaitForSeconds(retractionDelay);

        // Retraction
        yield return StartCoroutine(RetractBridge());
    }

    private IEnumerator ExtendBridge()
    {
        float elapsedTime = 0f;
        Vector3 initialScale = bridgeTransform.localScale;
        Vector3 targetScale = new Vector3(bridgeExtensionOffset, initialScale.y, initialScale.z);

        Vector3 initialPosition = bridgeTransform.position;
        float halfWidthChange = (targetScale.x - initialScale.x) / 2;
        Vector3 targetPosition = initialPosition + new Vector3(halfWidthChange, 0, 0);

        while (elapsedTime < extensionTime)
        {
            float lerpValue = elapsedTime / extensionTime;
            bridgeTransform.localScale = Vector3.Lerp(initialScale, targetScale, lerpValue);
            bridgeTransform.position = Vector3.Lerp(initialPosition, targetPosition, lerpValue);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        bridgeTransform.localScale = targetScale;
        bridgeTransform.position = targetPosition;
    }

    private IEnumerator RetractBridge()
    {
        float elapsedTime = 0f;
        Vector3 initialScale = bridgeTransform.localScale;
        Vector3 targetScale = new Vector3(1, initialScale.y, initialScale.z);

        Vector3 initialPosition = bridgeTransform.position;
        float halfWidthChange = (targetScale.x - initialScale.x) / 2;
        Vector3 targetPosition = initialPosition + new Vector3(halfWidthChange, 0, 0);

        while (elapsedTime < extensionTime)
        {
            float lerpValue = elapsedTime / extensionTime;
            bridgeTransform.localScale = Vector3.Lerp(initialScale, targetScale, lerpValue);
            bridgeTransform.position = Vector3.Lerp(initialPosition, targetPosition, lerpValue);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        bridgeTransform.localScale = targetScale;
        bridgeTransform.position = targetPosition;
    }
}
