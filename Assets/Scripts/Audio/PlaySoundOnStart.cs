using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{
    [SerializeField] private soundType _soundType;
    [SerializeField] private string _soundName;

    private void Start()
    {
        switch (_soundType)
        {
            case soundType.music:
                AudioSystem.Instance.PlayMusic(_soundName);
                break;
            case soundType.environment:
                AudioSystem.Instance.PlayEnvironment(_soundName);
                break;
            case soundType.effect:
                AudioSystem.Instance.PlayEffect(_soundName);
                break;
            default:
                break;
        }
    }

    enum soundType
    {
        music,
        environment,
        effect
    }
}
