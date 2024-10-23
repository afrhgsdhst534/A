using UnityEngine;
using UnityEngine.UI;
public class RacoonBodyObj : MonoBehaviour
{
    private Text timer;
    private Text hpT;
    private Text pointsT;
    public float timerF;
    public UniqueSpell us;
    public int hp = 1;
    public int points;
    public int pointsEnd;
    private void Start()
    {
        timer = transform.GetChild(0).GetComponent<Text>();
        hpT = transform.GetChild(1).GetComponent<Text>();
        pointsT = transform.GetChild(2).GetComponent<Text>();
        timerF = 40;
    }
    private void Update()
    {
        timer.text = timerF.ToString();
        hpT.text = hp.ToString();
        pointsT.text = points.ToString()+" / "+pointsEnd.ToString();
        timerF -= Time.deltaTime;
        if (timerF < 0)
        {
            us.GameOver();
        }
        if (hp < 1)
        {
            us.GameOver();
        }
        if (points >= pointsEnd)
        {
            us.Win();
        }
    }
}