using UnityEngine;
public class AimUpgrade : Upgrade
{
    public override void OnUpgrade(GameObject player)
    {
        player.GetComponent<BaseÑharacteristic>().attackRange += 15;
    } 
}