using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUpSO")]
public class PowerUpSO : ScriptableObject
{
    [SerializeField] string powerUpType;
    [SerializeField] float valueChange;
    [SerializeField] float duration;

    public string getPowerUpType()
    {
        return powerUpType;
    }

    public float getValueChange()
    {
        return valueChange;
    }

    public float getDuration()
    {
        return duration;
    }
}
