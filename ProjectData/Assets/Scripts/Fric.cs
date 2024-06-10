using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fric : MonoBehaviour
{
    [SerializeField] Vector2 prevPos;
    [SerializeField] Vector2 targPos;

    //フリック判定用 時間しきい値
    [SerializeField] float flickTime = 0.15f;
    //フリック判定用 移動距離
    [SerializeField] float flickMagnitude = 100;
    // ひっぱり判定用
    [SerializeField] float graspThreshold = 1.0f;
    //フリック判定用 ローカルタイマー
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // タップされたとき
            prevPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            timer = 0.0f;
        }
        else if (Input.GetMouseButton(0))
        { // タップ長押し中
            targPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 diffPos = targPos - new Vector2(transform.position.x, transform.position.y);

            // ひっぱり判定
            float magnitude = diffPos.magnitude; // ひっぱりの強さ（距離依存）
            float rad = Mathf.Atan2(diffPos.y, diffPos.x); // ひっぱり角度
            // ひっぱり時のアクション
            this.transform.localEulerAngles = new Vector3(0f, 0f, rad * Mathf.Rad2Deg);
            this.transform.localScale = new Vector2(magnitude, magnitude);
            // タイマー更新処理
            timer += Time.deltaTime;
        }
        else if (Input.GetMouseButtonUp(0))
        { // タップを離したとき
            targPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isFrickd(targPos - prevPos);
            timer = 0.0f;
        }
    }

    void isFrickd(Vector2 mouseMove)
    {
        // フリック判定
        // 距離が指定以上、タップ時間が指定以下の場合、フリックと判定
        if (mouseMove.magnitude >= flickMagnitude && timer <= flickTime)
        {
            //x軸の距離が大きい場合は左右へのフリック
            if (Mathf.Abs(mouseMove.x) >= Mathf.Abs(mouseMove.y))
            {
                if (mouseMove.x >= 0)
                {
                    Debug.Log("Right Frick");
                }
                else
                {
                    Debug.Log("Left Frick");
                }
            }
            //y軸の距離が大きい場合は上下のフリック
            else if (Mathf.Abs(mouseMove.x) < Mathf.Abs(mouseMove.y))
            {
                if (mouseMove.y >= 0)
                {
                    Debug.Log("Up Flick");
                }
                else
                {
                    Debug.Log("Down Flick");
                }
            }
        }
    }
}