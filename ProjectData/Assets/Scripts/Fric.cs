using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fric : MonoBehaviour
{
    [SerializeField] Vector2 prevPos;
    [SerializeField] Vector2 targPos;

    //�t���b�N����p ���Ԃ������l
    [SerializeField] float flickTime = 0.15f;
    //�t���b�N����p �ړ�����
    [SerializeField] float flickMagnitude = 100;
    // �Ђ��ς蔻��p
    [SerializeField] float graspThreshold = 1.0f;
    //�t���b�N����p ���[�J���^�C�}�[
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // �^�b�v���ꂽ�Ƃ�
            prevPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            timer = 0.0f;
        }
        else if (Input.GetMouseButton(0))
        { // �^�b�v��������
            targPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 diffPos = targPos - new Vector2(transform.position.x, transform.position.y);

            // �Ђ��ς蔻��
            float magnitude = diffPos.magnitude; // �Ђ��ς�̋����i�����ˑ��j
            float rad = Mathf.Atan2(diffPos.y, diffPos.x); // �Ђ��ς�p�x
            // �Ђ��ς莞�̃A�N�V����
            this.transform.localEulerAngles = new Vector3(0f, 0f, rad * Mathf.Rad2Deg);
            this.transform.localScale = new Vector2(magnitude, magnitude);
            // �^�C�}�[�X�V����
            timer += Time.deltaTime;
        }
        else if (Input.GetMouseButtonUp(0))
        { // �^�b�v�𗣂����Ƃ�
            targPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isFrickd(targPos - prevPos);
            timer = 0.0f;
        }
    }

    void isFrickd(Vector2 mouseMove)
    {
        // �t���b�N����
        // �������w��ȏ�A�^�b�v���Ԃ��w��ȉ��̏ꍇ�A�t���b�N�Ɣ���
        if (mouseMove.magnitude >= flickMagnitude && timer <= flickTime)
        {
            //x���̋������傫���ꍇ�͍��E�ւ̃t���b�N
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
            //y���̋������傫���ꍇ�͏㉺�̃t���b�N
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