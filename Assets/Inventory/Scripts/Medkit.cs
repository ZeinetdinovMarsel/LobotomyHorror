using UnityEngine;

public class Medkit : Item
{
    [SerializeField] private float _healAmount = 20;
    public override void Use(GameObject user, IInventory inventory)
    {
        var health = user.GetComponent<Health>();
        if (health != null)
        {
            health.Heal(_healAmount);
        }

        DropItem();
        inventory.RemoveItem();
    }

}
