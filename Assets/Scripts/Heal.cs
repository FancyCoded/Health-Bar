using UnityEngine;

public class Heal : MonoBehaviour
{
    public float HealingHitPoints { get; private set; }

    private void Awake()
    {
        HealingHitPoints = 10;
    }

    public void ToHeal(Player player)
    {
        player.TakeHeal(HealingHitPoints);
    }
}