using UnityEngine;
public class LeavingMeat : Item
{
    public GameObject skeleton;
    public override void OnPick(GameObject obj)
    {
        base.OnPick(obj);
    }
    public override void OnDrop()
    {
        base.OnDrop();
    }
    public override void OnUse()
    {
        var manager = player.GetComponent<BuffManager>();
        for(int i = 0; i < manager.buffs.Count; i++)
        {
            manager.BuffRemove(manager.buffs[i]);
        }
        Vector3 vector3 = new Vector3(player.transform.position.x + 1, player.transform.position.y, player.transform.position.z + 1);
        Instantiate(skeleton,vector3, Quaternion.identity);
        Destroy(gameObject);
    }
}