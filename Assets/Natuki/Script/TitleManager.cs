using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// system�\���̕ϐ��ЂƂ܂Ƃ߂��܂����B
/// </summary>
[System.Serializable]
public struct SystemDataSet
{
    public GameObject startButton; //�J�n�{�^��
    public GameObject exitButton; //�I���{�^��
    public Text startText; //�J�n�{�^�����ɂ���e�L�X�g

}

public class TitleManager : MonoBehaviour
{
    //�_�ŏ��������֘A�ϐ�
    float time;
    float speed = 0.5f;

    public SystemDataSet system; //���̐錾

    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartBUtton()
    {
        system.startButton.SetActive(false);
        system.exitButton.SetActive(false);
    }

    /// <summary>
    /// �_�ŏ����֐�
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    Color Text_Invicivil(Color color)
    {
        time += Time.deltaTime * 5.0f * speed; //�_�ł��鑬�x�ݒ�
        color.a = Mathf.Sin(time); //���l��ύX���ē_�ŏ����𑣂�


        return color; //������ɕԂ�
    }

    // Update is called once per frame
    void Update()
    {
        system.startText.color = Text_Invicivil(system.startText.color); //�Ԃ����l�ɑ�����֐��ɓn��

    }
}
