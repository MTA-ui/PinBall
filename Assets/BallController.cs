using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    private int score = 0;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    private GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        this.scoreText = GameObject.Find("ScoreText");

        this.scoreText.GetComponent<Text>().text = "Score：" + score;
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    void OnCollisionEnter(Collision col)
    {
        int beforeScore = score;
        if(col.gameObject.tag == "SmallStarTag")
        {
            score += 10;
        }
        if (col.gameObject.tag == "LargeStarTag")
        {
            score += 20;
        }
        if (col.gameObject.tag == "SmallCloudTag")
        {
            score += 50;
        }
        if (col.gameObject.tag == "LargeCloudTag")
        {
            score += 100;
        }
        if (score > beforeScore)
        {
            this.scoreText.GetComponent<Text>().text = "Score：" + score;
        }
    }
}
