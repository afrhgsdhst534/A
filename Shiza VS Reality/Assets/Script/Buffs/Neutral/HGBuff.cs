using Lean.Localization;
using UnityEngine;
public class HGBuff : Buff
{
    private void OnEnable()
    { 
        GetComponentInChildren<LeanLocalizedText>().TranslationName = GetType().Name;
    }
    public override void OnAwake(GameObject obj)
    {
        base.OnAwake(obj);
        obj.GetComponent<BaseÑharacteristic>().armour += 5;
        player = obj;
    }
    public void OnDestroy()
    {
        player.GetComponent<BaseÑharacteristic>().armour -= 5;
    }
}