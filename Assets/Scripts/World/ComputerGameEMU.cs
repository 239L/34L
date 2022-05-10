using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ComputerGameEMU : MonoBehaviour
{
    [SerializeField] GameObject[] crosses;
    [SerializeField] GameObject[] circles;
    [SerializeField] GameObject slots;
    [SerializeField] GameObject selection;
    [SerializeField] GameObject selections;

    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject closeButton;
    public static bool start_trigger = false;

    [SerializeField] int[] moves = new int[9];

    public int[] Moves { get => moves; set => moves = value; }

    [SerializeField] GameObject[] results;
    int steps, me, you;

    public int Steps{ get => steps; set => steps = value; }

    public int Me { get => me; set => me = value; }

    public int You { get => you; set => you = value; }

    float time_to_think;

   

    public float Time_To_Think { get => time_to_think; set => time_to_think = value; }

    bool first, playerTurn;

    bool restart = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void startGame() {
        start_trigger = true;
    }

    public void restartGame() {
        restart = true;
    }

    void removeSelection() {
        selection.SetActive(false);
    }
    public void checkMove(int number) {
        selections.SetActive(false);
        if (moves[number] == 0)
        {
            me = number;
            performMove();
            time_to_think = Random.Range(1f, 3f);
            StartCoroutine(waitForTurn());
        }
    }

    IEnumerator waitForTurn() {
        yield return new WaitUntil(()=>playerTurn);
        selections.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (start_trigger)
        {
            Invoke("removeSelection", 0.3f);
            if (restart)
            {
                nullify();
                slots.SetActive(true);
                selections.SetActive(true);
                steps = 0;
                for (int i = 0; i < results.Length; i++)
                {
                    results[i].SetActive(false);
                }
                time_to_think = Random.Range(1f, 3f);
                if (Random.Range(0f, 1f) <= 0.5f) { first = playerTurn = false; } else { first = playerTurn = true; }
                restart = false;
            }


            if (!playerTurn && steps < 9)
            {
                if (time_to_think <= 0)
                {
                    do
                    {
                        you = Random.Range(0, 9);
                    } while (moves[you] != 0);
                    performMove();
                }
                else { time_to_think -= Time.deltaTime; }
            }

            if (steps == 9)
            {

                restart = true;
            }
        }
    }

    void makeVisible(GameObject g) {
        Color c = new Color(1, 1, 1, 1);
        g.GetComponent<Image>().color = c;
    }
    void makeInvisible(GameObject g)
    {
        Color c = new Color(1, 1, 1, 0);
        g.GetComponent<Image>().color = c;
    }
    public void performMove() {
        switch (playerTurn)
        {
            case true:

                closeButton.SetActive(false);
                SoundController.playSE(SE.PRESS2);
                if (first)
                {
                    moves[me] = 2;
                    makeVisible(crosses[me]);
                }
                else { moves[me] = 1;
                    makeVisible(circles[me]);
                } break;
            case false:
            default:
                closeButton.SetActive(true);
                SoundController.playSE(SE.PRESS3);
                if (first)
                {
                    moves[you] = 1;
                    
                    makeVisible(circles[you]);
                }
                else {
                    moves[you] = 2;
                    
                    makeVisible(crosses[you]);
                }
                break;
        }
        steps++;
        for (int i = 1; i < 3; i++)
        {
            if (Check(i)) { Finish();break; }
        }

        playerTurn = !playerTurn;
    }

   

    bool Check(int i) {
        return (moves[0] == i && moves[1] == i && moves[2] == i) ||
            (moves[3] == i && moves[4] == i && moves[5] == i) ||
             (moves[6] == i && moves[7] == i && moves[8] == i) ||
              (moves[0] == i && moves[3] == i && moves[6] == i) ||
               (moves[1] == i && moves[4] == i && moves[7] == i) ||
                (moves[2] == i && moves[5] == i && moves[8] == i) ||
                 (moves[0] == i && moves[4] == i && moves[8] == i) ||
                  (moves[2] == i && moves[4] == i && moves[6] == i);
    }

    void nullify() {
        for (int i = 0; i < crosses.Length; i++)
        {
            makeInvisible(crosses[i]);
            makeInvisible(circles[i]);
            moves[i] = 0;

        }
    }
    void Finish() {
        steps = 10;
        nullify();
        selections.SetActive(false);
        slots.SetActive(false);
        if (playerTurn) {
            results[0].SetActive(true);
            start_trigger = false;
            restartButton.SetActive(false);
            EventsController.instance.setGoldenKeyBool();
            SoundController.playME(ME.EVENT);
            closeButton.SetActive(true);
        }
        else { Invoke("Lose", 0.3f); }
    }

    void Lose() {
        SoundController.playME(ME.EFFECT2);
        results[1].SetActive(true);
        nullify();
    }
}
