using UnityEngine;
public class AimUpgrade : Upgrade
{
    public override void OnUpgrade(GameObject player)
    {
        player.GetComponent<Base�haracteristic>().attackRange += 15;
    } 
}