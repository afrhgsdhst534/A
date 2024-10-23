using UnityEngine;
public class InputButtons : MonoBehaviour
{
    public static InputButtons instance;
    public KeyCode attack;
    public KeyCode firstSpell = KeyCode.Z;
    public KeyCode secondSpell = KeyCode.X;
    public KeyCode thirdSpell = KeyCode.C;
    public KeyCode fourthSpell = KeyCode.V;
    public KeyCode item1;
    public KeyCode item2;
    public KeyCode item3;
    public KeyCode item4;
    public KeyCode item5;
    public KeyCode item6;
    public KeyCode w = KeyCode.W;
    public KeyCode a = KeyCode.A;
    public KeyCode s = KeyCode.S;
    public KeyCode d = KeyCode.D;
    public void OnEnable()
    {
        w = KeyCode.W;
        a = KeyCode.A;
        s = KeyCode.S;
        d = KeyCode.D;
        item1 = KeyCode.Alpha1;
        item2 = KeyCode.Alpha2;
        item3 = KeyCode.Alpha3;
        item4 = KeyCode.Alpha4;
        item5 = KeyCode.Alpha5;
        item6 = KeyCode.Alpha6;
        firstSpell = KeyCode.Z;
        secondSpell = KeyCode.X;
        thirdSpell = KeyCode.C;
        fourthSpell = KeyCode.V;
        attack = KeyCode.KeypadEnter;
        instance = this;
    }
}