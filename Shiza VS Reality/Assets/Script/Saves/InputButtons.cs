using UnityEngine;
public class InputButtons : MonoBehaviour
{
    public static InputButtons instance;
    [HideInInspector]
    public KeyCode attack;
    [HideInInspector]
    public KeyCode firstSpell ;
    [HideInInspector]
    public KeyCode secondSpell ;
    [HideInInspector]
    public KeyCode thirdSpell ;
    [HideInInspector]
    public KeyCode fourthSpell;
    [HideInInspector]
    public KeyCode item1;
    [HideInInspector]
    public KeyCode item2;
    [HideInInspector]
    public KeyCode item3;
    [HideInInspector]
    public KeyCode item4;
    [HideInInspector]
    public KeyCode item5;
    [HideInInspector]
    public KeyCode item6;
    [HideInInspector]
    public KeyCode w ;
    [HideInInspector]
    public KeyCode a ;
    [HideInInspector]
    public KeyCode s ;
    [HideInInspector]
    public KeyCode d ;
    public void Awake()
    {
        //Можно запихнуть  в свою библиотеку
        instance = this;
        w = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("W"));
        a = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("A"));
        s = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("S"));
        d = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("D"));
        item1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("ONE"));
        item2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("TWO"));
        item3 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("THREE"));
        item4 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("FOUR"));
        item5 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("FIVE"));
        item6 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("SIX"));
        firstSpell = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Z"));
        secondSpell = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("X"));
        thirdSpell = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("C"));
        fourthSpell = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("V"));
        attack = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("ATTACK"));
    }
}