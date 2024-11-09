using UnityEngine;
using System;
using UnityEngine.UI;
using KeyBinder;
using System.Collections.Generic;
public class Saves : MonoBehaviour
{
    public Toggle arrowIsFollowMouse;
    public Slider slider;
    private const string AIFM = "AIFM";
    private const string volume = "VOLUME";
    private const string attack = "ATTACK";
    private const string one = "ONE";
    private const string two = "TWO";
    private const string three = "THREE";
    private const string four = "FOUR";
    private const string five = "FIVE";
    private const string six = "SIX";
    private const string z = "Z";
    private const string x = "X";
    private const string c = "C";
    private const string v = "V";
    private const string w = "W";
    private const string a = "A";
    private const string s = "S";
    private const string d = "D";
    private string keyString;
    public List<Text> keyText;
    private void Start()
    {
        keyText[0].text = PlayerPrefs.GetString(attack);
        keyText[1].text = PlayerPrefs.GetString(one);
        keyText[2].text = PlayerPrefs.GetString(two);
        keyText[3].text = PlayerPrefs.GetString(three);
        keyText[4].text = PlayerPrefs.GetString(four);
        keyText[5].text = PlayerPrefs.GetString(five);
        keyText[6].text = PlayerPrefs.GetString(six);
        keyText[7].text = PlayerPrefs.GetString(z);
        keyText[8].text = PlayerPrefs.GetString(x);
        keyText[9].text = PlayerPrefs.GetString(c);
        keyText[10].text = PlayerPrefs.GetString(v);
        keyText[11].text = PlayerPrefs.GetString(w);
        keyText[12].text = PlayerPrefs.GetString(a);
        keyText[13].text = PlayerPrefs.GetString(s);
        keyText[14].text = PlayerPrefs.GetString(d);
        arrowIsFollowMouse.isOn = Convert.ToBoolean(PlayerPrefs.GetInt(AIFM));
        slider.value = PlayerPrefs.GetFloat(volume);
        KeyDetector.InputCheckSetActive(true);
        KeyDetector.KeyReceived += DetectorKey;
    }
    private void OnDestroy()
    {
        KeyDetector.KeyReceived -= DetectorKey;
    }
    void DetectorKey(KeyCode code)
    {
        switch (keyString)
        {

            case "Attack":
                keyText[0].text = code.ToString();
                PlayerPrefs.SetString(attack, code.ToString());
                keyString = "";
                break;
            case "1":
                keyText[1].text = code.ToString();
                PlayerPrefs.SetString(one, code.ToString());
                keyString = "";
                break;
            case "2":
                keyText[2].text = code.ToString();
                PlayerPrefs.SetString(two, code.ToString());
                keyString = "";
                break;
            case "3":
                keyText[3].text = code.ToString();
                PlayerPrefs.SetString(three, code.ToString());
                keyString = "";
                break;
            case "4":
                keyText[4].text = code.ToString();
                PlayerPrefs.SetString(four, code.ToString());
                keyString = "";
                break;
            case "5":
                keyText[5].text = code.ToString();
                PlayerPrefs.SetString(five, code.ToString());
                keyString = "";
                break;
            case "6":
                keyText[6].text = code.ToString();
                PlayerPrefs.SetString(six, code.ToString());
                keyString = "";
                break;
            case "Z":
                keyText[7].text = code.ToString();
                PlayerPrefs.SetString(z, code.ToString());
                keyString = "";
                break;
            case "X":
                keyText[8].text = code.ToString();
                PlayerPrefs.SetString(x, code.ToString());
                keyString = "";
                break;
            case "C":
                keyText[9].text = code.ToString();
                PlayerPrefs.SetString(c, code.ToString());
                keyString = "";
                break;
            case "V":
                keyText[10].text = code.ToString();
                PlayerPrefs.SetString(v, code.ToString());
                keyString = "";
                break;
            case "W":
                keyText[11].text = code.ToString();
                PlayerPrefs.SetString(w, code.ToString());
                keyString = "";
                break;
            case "A":
                keyText[12].text = code.ToString();
                PlayerPrefs.SetString(a, code.ToString());
                keyString = "";
                break;
            case "S":
                keyText[13].text = code.ToString();
                PlayerPrefs.SetString(s, code.ToString());
                keyString = "";
                break;
            case "D":
                keyText[14].text = code.ToString();
                PlayerPrefs.SetString(d, code.ToString());
                keyString = "";
                break;
        }
    }
    public void KeyString(string str)
    {
        keyString = str;
    }
    public void Update()
    {
        PlayerPrefs.SetInt(AIFM, Convert.ToInt32(arrowIsFollowMouse.isOn));
        PlayerPrefs.SetFloat(volume, slider.value);
    }
}