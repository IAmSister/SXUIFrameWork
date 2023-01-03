
using System.Collections;
using UnityEngine;
using GCGame.Table;

namespace Games.GlobeDefine
{
    public class GlobeVar
    {
        //Static ����
        public static bool s_FirstInitGame = true;         //��һ�ν�����Ϸ��ʾ

        //Const ����
        public const int INVALID_ID = -1;                   //�Ƿ�ID
        public const string characTorPath = "";

        public const System.UInt64 INVALID_GUID = 0xFFFFFFFFFFFFFFFFul;        //�Ƿ�GUID

        //////////////////////////////////////////////////////////////////////////
        //������ض���
        //////////////////////////////////////////////////////////////////////////
        public const int MAX_TEAM_MEMBER = 4;               //�����������

        //��ְͬҵ��ͷ����Ϣ
       // public static string[] m_HeadIcon = new string[(int)CharacterDefine.PROFESSION.MAX] { "Player_JianKe", "Player_CiKe", "Player_QiangKe", "Player_PuShan" };

        public const int MAX_LAST_SPEAKERS = 20;        // ������ϴη�����Ҽ�¼�������

        public const int MAX_FRIEND_NUM = 20;          // ��Һ�������
        public const int MAX_BLACK_NUM = 20;           // ��Һ���������

        public const int YanMenGuan_QiaoFengAni = 86;
        public const int YanMenGuan_QiaoFengZhenPing = 54;

        public const int YanMenGuan_BossAni = 85;

        public const int YanMenGuan_BeforeQingGongStoryID = 14;
        public const int YanMenGuan_BossStory1ID = 55;
        public const int YanMenGuan_BossStory2ID = 15;

        public const int YanMenGuan_ModelStoryID = 0;
        public const int YanmMenGuan_QingGongID_Over = 2;

        public const int EmotionTiger_Num = 60;

        public static string[] QualityColorGrid = { "ui_pub_012", "ui_pub_013", "ui_pub_014", "ui_pub_015", "ui_pub_016" };

        public const int PosionForgDataID = 44;

        public const int CompountDataID = 8001;

        public const int QianLiChuanYinDataID = 4031;

        public const int MAX_FASHION_SIZE = 20;

        public const int MARRY_PARADE_STORY = 60;//�νֹ���ģʽ

        //GameObject Pool���
        public const int POOL_MAX_CAPACITY = 256;       //GameObject Pool�������������ܳ��ȣ�����֮��ֹͣ�����������������־

        //���
        public const int CREATE_GUILD_LEVEL = 40;       //��ᴴ���ȼ�
        public const int JOIN_GUILD_LEVEL = 20;         //������ȼ�
        public const int MAX_GUILD_NAME = 12;           //������ֳ���
        public const int MAX_GUILD_NOTICE = 60;         //��ṫ�泤��
        public const int MAX_GUILD_MAIL = 60;           // ����ʼ�����
        public const int MAX_GUILD_LVL = 5;			// ������ߵȼ�

        public static int[] GUILD_MAX_MEMBER = { 60, 80, 100, 120, 140 };
        public static int GetGuildMemberMax(int nLevel)
        {
            //���ڰ��ȼ���1-5����������Ϊ0-4��������Ҫ����-1����
            nLevel = nLevel - 1;
            if (nLevel >= 0 && nLevel < GUILD_MAX_MEMBER.Length)
            {
                return GUILD_MAX_MEMBER[nLevel];
            }

            return 0;
        }

        //public static int[] GUILD_MAX_EXP = { 10000, 20000, 30000, 40000, 50000 };
        public static int GetGuildExpMax(int nLevel)
        {
            //Tab_GuildAutoLevelUp table = TableManager.GetGuildAutoLevelUpByID(nLevel, 0);
            //if (null != table)
            //{
            //    return table.NeedGuildExp;
            //}

            return 0;
        }

        //����Ա���֣��ֵ���ȱ
        public static string[] GUILD_JOB_NAME = { "�峤", "���峤", "����", "Ԥ����Ա" };

        public const int DEFAULT_VISUAL_ID = 0;         //Ĭ�����ID

        public const int NewButtonEffect = 65;

        public static Vector3 INFINITY_FAR = new Vector3(-1000.0f, -1000.0f, -1000.0f);

        //͸��ɫ
        public static Color TRANSPARENT_COLOR = new Color(1, 1, 1, 0.005f);

        //ʦ��
        public const int MAX_MASTER_NAME = 12;              //ʦ������������� 6����
        public const int MAX_MASTER_NOTICE = 64;            //ʦ�Ź���������� 32����
        public const int CREATE_MASTER_LEVEL = 60;
        public const int MAX_MASTER_MEMBER_NUM = 100;       //ʦ������Ա����
        public const int MAX_MASTER_SKILL_NAME = 12;        //ʦ�ż�������������� 6����

        //����
        public const int MAX_STAMINA = 100;         // ����������ֵ����ֵ
        public const int STAMINA_BUYVALUE = 100;    // ���ÿ�ι�������ֵ

        //���ʱ�ɫMaterial
        public const float BLUEMATERIAL_R = 0.208f;
        public const float BLUEMATERIAL_G = 0.565f;
        public const float BLUEMATERIAL_B = 0.741f;

        //װ��
        public const int EQUIP_ENCHANCE_MAX_LEVEL = 60;     //ǿ�����ȼ�

        //������⼼�ܶ���
        public const int MARRY_SKILL_1 = 90103;
        public const int MARRY_SKILL_2 = 90104;
        public const int MARRY_SKILL_3 = 90105;

        //ս������
        public const int COMBAT_LEVEL_1 = 300000;
        public const int COMBAT_LEVEL_2 = 400000;
        public const int COMBAT_LEVEL_3 = 500000;
        public const int COMBAT_EFFECT_1 = 169;
        public const int COMBAT_EFFECT_2 = 170;
        public const int COMBAT_EFFECT_3 = 171;


        public const int SKILLLEVUPEFFECTID = 193; //����������Ч

        public const int WuYingXunZongDataID = 59;

        public const int BIND_CHILDREN_MAX = 4;
        //���� ��������DataID
        public const int BLACKMAKETDATAID_SHUZHOU = 0;//174;
        //���� ��������DataID
        public const int BLACKMAKETDATAID_ERHAI = 911;
        //���� ���NPC
        public const int GUILDDATAID_SUZHOU = 214;
        //���� �ֿ�DataID
        public const int CANGKU1_SHUZHOU = 90101;
        //���� �ֿ�DataID
        public const int CANGKU2_SHUZHOU = 216;

        public const int USE_AUTOFIGHT_VIPLEVEL = 2;
        //������NPC
        public const int MARRY_NPCID = 848;
        public const int DIVORCE_NPCID = 849;
        public const int PARADE_NPCID = 933;
        public const int PARADE_BUSID = 934;
        //����ȡ�Ǳ����ѿ�ʼ����
        public const int PARTNER_GAIN_TIPS_LEVEL = 10;

        //����NPC
        public const int AWARD_NPCID = 12;

        //�Զ�ǿ������ 25�����Ͽ���ʹ��
        public const int MAX_AUTOEQUIT_LIVE = 25;

        //�������
        public const int GUILDBUSINESS_ACCEPTNPC = 268;
        public const int GUILDBUSINESS_MISSIONID_H = 301;
        public const int GUILDBUSINESS_MISSIONID_L = 302;

        //ʦ������npc
        public const int MASTERMISSION_ACCEPTNPC_DATAID = 0;//175;
    }
}
