using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI�֌W�ׂ̈̃��C�u����
using UnityEngine.SceneManagement; //���[�h�֌W��K�v�ȃ��C�u����

/// <summary>
/// system�\���̕ϐ��ЂƂ܂Ƃ߂��܂����B
/// </summary>
[System.Serializable]
public struct SystemDataSet
{
    public GameObject startButton; //�J�n�{�^��
    public GameObject exitButton; //�I���{�^��
    public Text startText; //�J�n�{�^�����ɂ���e�L�X�g
    public string LodedName;

}

public class TitleManager : MonoBehaviour
{
    //�_�ŏ��������֘A�ϐ�
    float time;
    float speed = 0.3f;

    public SystemDataSet system; //���̐錾

    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartBUtton()
    {
        SceneManager.LoadScene(system.LodedName);
    }

    /// <summary>
    /// �_�ŏ����֐�
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    Color Text_Invicivil(Color color)
    {
        time += Time.deltaTime * 4.0f * speed; //�_�ł��鑬�x�ݒ�
        color.a = Mathf.Sin(time); //���l��ύX���ē_�ŏ����𑣂�


        return color; //������ɕԂ�
    }

    // Update is called once per frame
    void Update()
    {
        system.startText.color = Text_Invicivil(system.startText.color); //�Ԃ����l�ɑ�����֐��ɓn��

    }
}
