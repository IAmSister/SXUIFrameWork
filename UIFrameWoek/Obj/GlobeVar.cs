
using System.Collections;
using UnityEngine;
using GCGame.Table;

namespace Games.GlobeDefine
{
    public class GlobeVar
    {
        //Static 定义
        public static bool s_FirstInitGame = true;         //第一次进入游戏标示

        //Const 定义
        public const int INVALID_ID = -1;                   //非法ID
        public const string characTorPath = "";

        public const System.UInt64 INVALID_GUID = 0xFFFFFFFFFFFFFFFFul;        //非法GUID

        //////////////////////////////////////////////////////////////////////////
        //队伍相关定义
        //////////////////////////////////////////////////////////////////////////
        public const int MAX_TEAM_MEMBER = 4;               //队伍最大人数

        //不同职业的头像信息
       // public static string[] m_HeadIcon = new string[(int)CharacterDefine.PROFESSION.MAX] { "Player_JianKe", "Player_CiKe", "Player_QiangKe", "Player_PuShan" };

        public const int MAX_LAST_SPEAKERS = 20;        // 聊天框上次发言玩家记录最大数量

        public const int MAX_FRIEND_NUM = 20;          // 玩家好友上限
        public const int MAX_BLACK_NUM = 20;           // 玩家黑名单上限

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

        public const int MARRY_PARADE_STORY = 60;//游街故事模式

        //GameObject Pool相关
        public const int POOL_MAX_CAPACITY = 256;       //GameObject Pool自增长的最大可能长度，超过之后停止自增长并输出错误日志

        //帮会
        public const int CREATE_GUILD_LEVEL = 40;       //帮会创建等级
        public const int JOIN_GUILD_LEVEL = 20;         //帮会加入等级
        public const int MAX_GUILD_NAME = 12;           //帮会名字长度
        public const int MAX_GUILD_NOTICE = 60;         //帮会公告长度
        public const int MAX_GUILD_MAIL = 60;           // 帮会邮件长度
        public const int MAX_GUILD_LVL = 5;			// 家族最高等级

        public static int[] GUILD_MAX_MEMBER = { 60, 80, 100, 120, 140 };
        public static int GetGuildMemberMax(int nLevel)
        {
            //由于帮会等级是1-5，但是索引为0-4，所以需要进行-1操作
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

        //帮会成员名字，字典暂缺
        public static string[] GUILD_JOB_NAME = { "族长", "副族长", "族人", "预备成员" };

        public const int DEFAULT_VISUAL_ID = 0;         //默认外观ID

        public const int NewButtonEffect = 65;

        public static Vector3 INFINITY_FAR = new Vector3(-1000.0f, -1000.0f, -1000.0f);

        //透明色
        public static Color TRANSPARENT_COLOR = new Color(1, 1, 1, 0.005f);

        //师门
        public const int MAX_MASTER_NAME = 12;              //师门名称最大字数 6汉字
        public const int MAX_MASTER_NOTICE = 64;            //师门公告最大字数 32汉字
        public const int CREATE_MASTER_LEVEL = 60;
        public const int MAX_MASTER_MEMBER_NUM = 100;       //师门最大成员数量
        public const int MAX_MASTER_SKILL_NAME = 12;        //师门技能名称最大字数 6汉字

        //体力
        public const int MAX_STAMINA = 100;         // 玩家最大体力值基础值
        public const int STAMINA_BUYVALUE = 100;    // 玩家每次购买体力值

        //材质变色Material
        public const float BLUEMATERIAL_R = 0.208f;
        public const float BLUEMATERIAL_G = 0.565f;
        public const float BLUEMATERIAL_B = 0.741f;

        //装备
        public const int EQUIP_ENCHANCE_MAX_LEVEL = 60;     //强化最大等级

        //结婚特殊技能动作
        public const int MARRY_SKILL_1 = 90103;
        public const int MARRY_SKILL_2 = 90104;
        public const int MARRY_SKILL_3 = 90105;

        //战力区分
        public const int COMBAT_LEVEL_1 = 300000;
        public const int COMBAT_LEVEL_2 = 400000;
        public const int COMBAT_LEVEL_3 = 500000;
        public const int COMBAT_EFFECT_1 = 169;
        public const int COMBAT_EFFECT_2 = 170;
        public const int COMBAT_EFFECT_3 = 171;


        public const int SKILLLEVUPEFFECTID = 193; //技能升级特效

        public const int WuYingXunZongDataID = 59;

        public const int BIND_CHILDREN_MAX = 4;
        //苏州 黑市商人DataID
        public const int BLACKMAKETDATAID_SHUZHOU = 0;//174;
        //洱海 黑市商人DataID
        public const int BLACKMAKETDATAID_ERHAI = 911;
        //苏州 帮会NPC
        public const int GUILDDATAID_SUZHOU = 214;
        //苏州 仓库DataID
        public const int CANGKU1_SHUZHOU = 90101;
        //苏州 仓库DataID
        public const int CANGKU2_SHUZHOU = 216;

        public const int USE_AUTOFIGHT_VIPLEVEL = 2;
        //结婚相关NPC
        public const int MARRY_NPCID = 848;
        public const int DIVORCE_NPCID = 849;
        public const int PARADE_NPCID = 933;
        public const int PARADE_BUSID = 934;
        //伙伴抽取角标提醒开始级别
        public const int PARTNER_GAIN_TIPS_LEVEL = 10;

        //奖励NPC
        public const int AWARD_NPCID = 12;

        //自动强化功能 25级以上可以使用
        public const int MAX_AUTOEQUIT_LIVE = 25;

        //帮会跑商
        public const int GUILDBUSINESS_ACCEPTNPC = 268;
        public const int GUILDBUSINESS_MISSIONID_H = 301;
        public const int GUILDBUSINESS_MISSIONID_L = 302;

        //师门任务npc
        public const int MASTERMISSION_ACCEPTNPC_DATAID = 0;//175;
    }
}
