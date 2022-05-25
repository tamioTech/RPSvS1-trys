using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{

    [SerializeField] Transform gloveHome, newspaperHome, swordHome;
    [SerializeField] GameObject p2a1, p2a2, p2a3, p2b1, p2b2, p2b3, expP1gao, expP2gao;
    [SerializeField] GameObject scoreboard, bombGao, p1Crown, p2Crown;
    [SerializeField] private int score = 2;
    [SerializeField] Slider scoreboardSlider;
    [SerializeField] ParticleSystem expP1;
    [SerializeField] ParticleSystem expP2;
    [SerializeField] SpriteRenderer p1SR;
    [SerializeField] SpriteRenderer p2SR;

    private string P1a, P1b, P2a, P2b = null;
    private string[] rdmDraw = new string[] { "BoxingGlove", "Newspaper", "Sword" };
    private int gameStartScore = 3;
    bool slotAFilled, slotBFilled, battling, gameOn;

    DJMickeyMouse dj;
    Bomb bomb;
    AudioSource bombAudioSource;
    GameHandler gameHandler;




    private void Awake()
    {
        scoreboardSlider = scoreboard.GetComponent<Slider>();
        dj = FindObjectOfType<DJMickeyMouse>();
        bomb = FindObjectOfType<Bomb>();
        bombAudioSource = bomb.GetComponent<AudioSource>();
        gameHandler = FindObjectOfType<GameHandler>();
        slotAFilled = false;
        slotBFilled = false;
        battling = false;
        gameOn = true;
        score = gameStartScore;
        bombGao.SetActive(true);
        p1SR.color = new Color(1, 1, 1, 1);
        p2SR.color = new Color(1, 1, 1, 1);
        p1Crown.SetActive(false);
        p2Crown.SetActive(false);
        expP1gao.SetActive(false);
        expP2gao.SetActive(false);
    }

    private void Update()
    {
        if (!slotAFilled || !slotBFilled) return;

        BeginBattleButtonPressed();
    }

#region P1Choices

    public void P1AChoice(string rpsChoice)
    {
        P1a = rpsChoice;
        slotAFilled = true;
    }

    public void P1BChoice(string rpsChoice)
    {

        P1b = rpsChoice;
        slotBFilled = true;
    }

#endregion

    public void BeginBattleButtonPressed()
    {
        if (!gameOn) return;
        Player2RandomCards();
        if (P1a == null || P2a == null) return;
        if (P1b == null || P2b == null) return;
        SlotABattle();
        SlotBBattle();
        UpdateScoreBoard();
        CheckScore();
        slotAFilled = false;
        slotBFilled = false;
        Invoke("NextRound", 1);
    }

    private void Player2RandomCards()
    {
        float rdmNum1 = UnityEngine.Random.Range(0, 3);
        float rdmNum2 = UnityEngine.Random.Range(0, 3);
        //float rdmNum3 = UnityEngine.Random.Range(0, 3);

        P2a = rdmDraw[Mathf.RoundToInt(rdmNum1)];
        P2b = rdmDraw[Mathf.RoundToInt(rdmNum2)];
        //P2c = rdmDraw[Mathf.RoundToInt(rdmNum3)];

        if (rdmNum1 == 0){p2a1.SetActive(true);}
        if (rdmNum1 == 1) { p2a2.SetActive(true); }
        if (rdmNum1 == 2) { p2a3.SetActive(true); }

        if (rdmNum2 == 0) { p2b1.SetActive(true); }
        if (rdmNum2 == 1) { p2b2.SetActive(true); }
        if (rdmNum2 == 2) { p2b3.SetActive(true); }

        //if (rdmNum3 == 0) { p2c1.SetActive(true); }
        //if (rdmNum3 == 1) { p2c2.SetActive(true); }
        //if (rdmNum3 == 2) { p2c3.SetActive(true); }

    }

    private void CheckScore()
    {
        if (score <= 0)
        {
            print("P1 is a loser...");
            p2Crown.SetActive(true);
            bomb.PlayExplosionSFX();
            gameHandler.P1Explosion();
            p1SR.color = new Color(1, 1, 1, .3f);
            dj.PlayLoserMusic();
            gameOn = false;
            bomb.NoP1Fuse();
            bomb.NoP2Fuse();
            bombGao.SetActive(false);
            return;
        }
        if (score >=6)
        {
            print("P1 WINS!!!");
            p1Crown.SetActive(true);
            bomb.PlayExplosionSFX();
            gameHandler.P2Explosion();
            p2SR.color = new Color(1, 1, 1, .3f);
            dj.PlayVictoryMusic();
            gameOn = false;
            bomb.NoP1Fuse();
            bomb.NoP2Fuse();
            bombGao.SetActive(false);
            return;
        }
        if(score == 1)
        {
            bomb.PlaySizzleSFX();
            dj.PlayPanicMusic();
            bomb.LightP1Fuse();
        }
        else if(score == 5)
        {
            bomb.PlaySizzleSFX();
            dj.PlayPanicMusic();
            bomb.LightP2Fuse();
        }
        else
        {
            dj.PlayMusic();
            bombAudioSource.Stop();
            bomb.NoP1Fuse();
            bomb.NoP2Fuse();
        }
    }

    private void SlotABattle()
    {
        if (P1a == P2a)
        {
            print("Tie game a");
        }
        if (P1a == "BoxingGlove" && P2a == "Sword")
        {
            print("player 1 wins a");
            score += 1;
        }
        if (P1a == "BoxingGlove" && P2a == "Newspaper")
        {
            print("player 1 loses a");
            score -= 1;
        }
        if (P1a == "Newspaper" && P2a == "BoxingGlove")
        {
            print("player 1 wins a");
            score += 1;
        }
        if (P1a == "Newspaper" && P2a == "Sword")
        {
            print("player 1 loses a");
            score -= 1;
        }
        if (P1a == "Sword" && P2a == "Newspaper")
        {
            print("player 1 wins a");
            score += 1;
        }
        if (P1a == "Sword" && P2a == "BoxingGlove")
        {
            print("player 1 loses a");
            score -= 1;
        }
        else
        {
            //print("slot a else statement");
        }
    }

    private void SlotBBattle()
    {
        if (P1b == P2b)
        {
            print("Tie game b");
        }
        if (P1b == "BoxingGlove" && P2b == "Sword")
        {
            print("player 1 wins b");
            score += 1;
        }
        if (P1b == "BoxingGlove" && P2b == "Newspaper")
        {
            print("player 1 loses b");
            score -= 1;
        }
        if (P1b == "Newspaper" && P2b == "BoxingGlove")
        {
            print("player 1 wins b");
            score += 1;
        }
        if (P1b == "Newspaper" && P2b == "Sword")
        {
            print("player 1 loses b");
            score -= 1;
        }
        if (P1b == "Sword" && P2b == "Newspaper")
        {
            print("player 1 wins b");
            score += 1;
        }
        if (P1b == "Sword" && P2b == "BoxingGlove")
        {
            print("player 1 loses b");
            score -= 1;
        }
        else
        {
            //print("slot b else statement");
        }
    }


    public void NextRound()
    {
        #region nullAndSetActiveFalse

        P1a = null;
        P2a = null;
        P1b = null;
        P2b = null;

        p2a1.SetActive(false);
        p2a2.SetActive(false);
        p2a3.SetActive(false);
        p2b1.SetActive(false);
        p2b2.SetActive(false);
        p2b3.SetActive(false);

        #endregion

        #region sendDraggablesHome

        Glove[] gloves = FindObjectsOfType<Glove>();
        for(int i = 0; i< gloves.Length; i++)
        {
            gloves[i].transform.position = gloveHome.position;
        }
        Newspaper[] newspapers = FindObjectsOfType<Newspaper>();
        for (int i = 0; i < newspapers.Length; i++)
        {
            newspapers[i].transform.position = newspaperHome.position;
        }
        Sword[] swords = FindObjectsOfType<Sword>();
        for (int i = 0; i < swords.Length; i++)
        {
            swords[i].transform.position = swordHome.position;
        }
        #endregion

    }

    public void ResetGame()
    {
        gameOn = true;
        NextRound();
        score = gameStartScore;
        UpdateScoreBoard();
    }

    private void UpdateScoreBoard()
    {
        scoreboardSlider.value = score;
    }

    public void P1Explosion()
    {
        expP1gao.SetActive(true);
        expP1.Play();
    }

    public void P2Explosion()
    {
        expP2gao.SetActive(true);
        expP2.Play();
    }

}
