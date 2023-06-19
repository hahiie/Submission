using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BPMSet : MonoBehaviour
{
    //BPM�֘A
    public float BPM;
    public float BPMStart;
    public Text BPMText;
    public Text BPMStartText;
    //�Ȃ̒����p
    public AudioClip SongIN;
    //�Z�b�g�p�p�l��
    public GameObject Panel;
    bool NowPanel = false;
    public GameObject maincam;

    //BPM�m�[�c�Ǘ�
    List<GameObject> BPMList = new List<GameObject>();
    public GameObject BPMNotes;
    int BPMNotesNum = 0;

    //BPM�m�[�c�X�^�[�g�S�[���I�u�W�F�N�g
    public GameObject StartObj;
    public GameObject GoalObj;
    // Start is called before the first frame update
    void Start()
    {
        while(BPMStart+(60f/(BPM))*BPMNotesNum < SongIN.length)//�X�^�[�g���ԁ{�ꔏ���̎���
        {
            GameObject NotesP = Instantiate(BPMNotes);//�I�u�W�F�N�g����
            NotesP.transform.SetParent(maincam.transform,false);//�e�̐ݒ�
            NotesMove2 move = NotesP.GetComponent<NotesMove2>();
            move.StartObj = StartObj;
            move.GoalObj = GoalObj;
            move.GoalTime = BPMStart + (60f / (BPM)) * BPMNotesNum;
            BPMList.Add(NotesP);
            BPMNotesNum++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        BPMText.text = BPM.ToString(".000");
        BPMStartText.text = BPMStart.ToString(".000");
        //�p�l��
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(NowPanel == false)
            {
                NowPanel = true;
                Panel.SetActive(true);
            }
            else
            {
                NowPanel = false;
                Panel.SetActive(false);
            }
        }

    }
    public void BPMPluse(float i)//���ԑ���
    {
        BPM = BPM + i;
        BPMReload();
    }
    public void BPMStartPluse(float i)//���ԑ���
    {
        BPMStart = BPMStart + i;
        BPMReload();
    }

    void BPMReload()//���ԑ���Ή�
    {
        int i = 0;
        while (BPMStart + (60f / (BPM)) * i < SongIN.length)
        {
            if(i< BPMNotesNum)
            {
                NotesMove2 move = BPMList[i].GetComponent<NotesMove2>();
                move.GoalTime = BPMStart + (60f / (BPM)) * i;
                i++;
            }
            else
            {
                GameObject NotesP = Instantiate(BPMNotes);//�I�u�W�F�N�g����
                NotesP.transform.SetParent(maincam.transform,false);//�J������e��
                NotesMove2 move = NotesP.GetComponent<NotesMove2>();
                move.StartObj = StartObj;
                move.GoalObj = GoalObj;
                move.GoalTime = BPMStart + (60f / (BPM)) * i;
                BPMList.Add(NotesP);
                i++;
            }
        }

        if (i < BPMNotesNum)
        {
            for (int j = i; j < BPMNotesNum; j++)
            {
                Destroy(BPMList[i]);
                BPMList.RemoveAt(i);
            }
        }
        BPMNotesNum = i;
    }
}