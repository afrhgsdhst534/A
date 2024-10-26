using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
public class PawOfRevenge : Spell
{
    private SpellManager manager;
    public override void OnAwake(GameObject obj)
    {
        base.OnAwake(obj);
        LvlLimit = 10;
        passive = true;
        manager = player.GetComponent<SpellManager>();
    }
    void AttackChanger()
    {
        Next();
    }
    async void Next()
    {
        await Task.Delay(21);
        var players = player.GetComponent<BaseÑharacteristic>().targets;
        var p = player.GetComponent<BaseÑharacteristic>();
        int value=0;
        for (int i = 0; i < manager.spells.Count; i++)
        {
            if (manager.spells[i] == this)
            {
                value = this.value;
            }
        }
        if (players != null && p.curMana>=5)
        {
            p.curMana-=5;
            for (int i = 0; i < players.Count; i++)
            {
                var playersBase = players[i].GetComponent<BaseÑharacteristic>();
                switch (p.attack >= 0)
                {
                    case true:
                       playersBase.DamageCalculations(p.attack + 10 * value, "physical");
                        break;
                    case false:
                        if (p.isAlly)
                        {
                            if (playersBase.isAlly)
                            {
                                playersBase.DamageCalculations(p.attack - 10 * value, "physical");
                            }
                            else
                            {
                                playersBase.DamageCalculations((p.attack* -2) + (10 * value), "physical");
                            }
                        }
                        else
                        {
                            if (playersBase.isAlly)
                            {
                                playersBase.DamageCalculations((p.attack * -2) + (10 * value), "physical");
                            }
                            else
                            {
                                playersBase.DamageCalculations(p.attack - 10 * value, "physical");
                            }
                        }
                        break;
                }
            }
        }
    }
    public override void Cast()
    {
        manager = player.GetComponent<SpellManager>();
        active = !active;
        switch(active)
        {
            case true:
                if (player.GetComponent<Attack>().attackObject!=null)
                {
                    player.GetComponent<Attack>().onAttack += AttackChanger;
                    var objct = manager.FindSpell(gameObject.GetComponent<Spell>());
                    objct.GetComponent<Image>().color = new Color(255, 0, 0, 100);
                }
                break;
            case false:
                if (player.GetComponent<Attack>().attackObject != null)
                {
                    player.GetComponent<Attack>().onAttack -= AttackChanger;
                    var objct = manager.FindSpell(gameObject.GetComponent<Spell>());
                    objct.GetComponent<Image>().color = new Color(255,255,255,100);
                }
                break;
        }
    }
    public override void Up()
    {
        base.Up();
        value++;
    }
}