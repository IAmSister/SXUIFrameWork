
using UnityEngine;
using System.Collections;

namespace Games.GlobeDefine
{
	public class GameDefine_Globe
	{
		//����ʯ��commonitem�е�ID
		public const int STAR_COMMONITEM_ID = 24;
		//������Чö��
		public enum EffectID
		{
			BEHIT = 5001,

		}
		//ö��
		public enum GAMESTATUS                  //��Ϸ״̬
		{
			GAMESTATUS_INVALID = -1,                //�Ƿ�״̬
			GAMESTATUS_LOGIN,                   //��¼״̬
			GAMESTATUS_MAIN,                    //����Ϸ״̬
			GAMESTATUS_NUM,                     //״̬����
		}

		public enum OBJ_TYPE                    //Obj����
		{
			OBJ,
			OBJ_CHARACTER,
			OBJ_NPC,
			OBJ_FELLOW,
			OBJ_OTHER_PLAYER,
			OBJ_MAIN_PLAYER,
			OBJ_ZOMBIE_PLAYER,
			OBJ_DROP_ITEM,
			OBJ_CLIENT,
			OBJ_SNARE,
			OBJ_YANHUA,
			OBJ_JUQINGITEM,
			OBJ_LUZHANG,
		}
		//NPC���0��ͨ 1��Ӣ 2 BOSS��
		public enum NPC_TYPE
		{
			NORMAL = 0,//��ͨ
			ELITE,//��Ӣ
			BOSS,//BOSS
		}
		//obj״̬ ��� !!!�������� ANIMATIONSTATE������һ��
		public enum OBJ_ANIMSTATE
		{
			STATE_INVAILD = -1,
			STATE_NORMOR = 0, //����
			STATE_WALK, //����
			STATE_HIT,//�ܻ�
			STATE_ATTACKDOWN,//����
			STATE_ATTACKFLY,//����
			STATE_DEATH,//����
			STATE_HITBYSHAOLIN,//�����ܻ����ܵ����ֵ��չ���
			STATE_HITBYTIANSHAN,//�����ܻ����ܵ���ɽ���չ���
			STATE_HITBYDALI,//�����ܻ����ܵ�������չ���
			STATE_HITBYXIAOYAO,//�����ܻ����ܵ���ң���չ���
			STATE_JUMP, //��Ծ
			STATE_JUMP_END,//��Ծ����
			STATE_FASTRUN_LEFT, //����б���ٱ���
			STATE_FASTRUN_RIGHT, //����б���ٱ���
			STATE_CORPSE,//ʬ��
		}
		public enum PACKET_DEFINE               //��Ϣ�����Ͷ��壬һ����������
		{
		}

		public enum EVENT_DEFINE                //�ͻ����¼���һ����������
		{
			EVENT_INVALID = -1,                 // �Ƿ��¼�
			EVENT_ENTERGAME,                    // ������Ϸ�¼�
			EVENT_CHANGESCENE,                  // �л�����
			EVENT_CONNECT_SUCCESS,              // ���ӷ������ɹ�
			EVENT_CONNECT_FAIL,                 // ���ӷ�����ʧ��
			EVENT_MISSION_COLLECTITEM,          // �ɼ����� ֱ���ܵ��˲ɼ�
			EVENT_COLLECTITEM_RESEED,           // �ɼ��� ˢ��

			EVENT_QINGGONG,                     // �ͻ����Ṧ
		}

		public enum SCENE_DEFINE
		{
			SCENE_WUSHENTA = 20,           // ������ �ؾ���
			SCENE_QIXINGXUANZHEN = 28,           // �������� �������
			SCENE_TIANXIAWUSHUANG = 23,           // ������˫ ��ɽ�۽�
			SCENE_HULAOGUAN = 16,           // ���ι� ����ׯ
			SCENE_HUSONGMEIREN = 19,           // ��������  ������
			SCENE_FENGHUOLIANTIAN = 31,           // ������� ��������ɽ
			SCENE_GUILDWAR = 11,           // ��ս����
			SCENE_YEXIDAYING = 21,           // ҹϮ��Ӫ ������Ĺ
			SCENE_WORLDBOSS = 35,           // ����BOSS
			SCENE_GUOGUANZHANJIANG = 22,           // ����ն�� ŭ������ ��ͷս��
			SCENE_RICHANGJUEDOU = 17,           // �ճ�����
			SCENE_LOGIN = 0,            // ��¼
			SCENE_ERHAI = 1,            // ����
			SCENE_SHAOSHISHAN = 2,            // ����ɽ
			SCENE_LOADINGSCENE = 38,            // loading
			SCENE_TIANSHAN = 4,            // ��ɽ
			SCENE_XINGZILIN = 5,            // ������
			SCENE_JIANHUGONG = 6,            // ������
			SCENE_WUDAOZHIDIAN = 8,            // ���֮�۸�������ʱΪ��ʱ��Դ                                 
			SCENE_XIAOJINGHU = 9,            // С����
			SCENE_YUQINGGONG = 10,           // ���幬
			SCENE_YANMENGUANWAI = 13,           // ���Ź���
			SCENE_SUZHOU = 12,           // ����
			SCENE_WANGYOUGU = 18,           // ���ǹ� ��������ͨ�ó���
			SCENE_JIANYU = 32,           // ����
			SCENE_WUCHANG = 33,           // �䳡
		}

		/// <summary>
		/// ����Ĭ�ϸ߶ȡ���Ӧ��Index �� SCENE_DEFINE��value (��SceneName ��Index)��Ӧ
		/// </summary>
		public static float[] SceneHeight =
		{
			0f,
			17.03708f,
			20.03166f,
			0f,
			15.12543f,
			21.66693f,
			15.16502f,
			7.216075f,
			22.20361f,
			15.83959f,
			22.38024f,
			0.0154163f,
			15.3999f,
			0f,
			14.995f,
			20.38571f,
			22.38024f,
			22.38024f,
			19.99328f,
			16.94185f,
			18.54701f,
			17.03708f,
			19.02887f,
			18.70577f,
			21.24829f,
			13.99058f,
			15.83897f,
			20.59491f,
			14.309f,
			0.01541439f,
			19.97823f,
			6.109085f,
			15.16502f,
			15.04783f,
			12.6f,
			19.17084f,
		};

		public static string[] SceneName = {
			"Login",//0
			"zc_jiangxia",//1
			"julu",//2
			"taoyuan",//3
			"HuLaoGuan",//4
			"fb_wushenta",//5
			"fb_yaobazhen",//6
			"fb_HuLaoGuan",//7
			"yw_WoLongGang",//8
			"zc_changan",//9
			"fengyiting",//10
			"fb_bangzhan",//11
			"yw_baimapo",//12
			"yw_xsbaimapo",//13
			"zc_jiangxia",//14
			"julu",//15
			"fb_HuLaoGuan",//16
			"fb_wudouchang",//17
			"zc_caofu",//18
			"fb_julu2",//19
			"fb_wushenta",//20
			"fb_yexidaying",//21
			"fb_guoguanzhanjiang",//22
			"fb_wudouchang",//23
			"yw_jinzhouchenwai",//24
			"xiangyang",//25
			"yw_chibi",//26
			"yw_maicheng",//27
			"fb_yaobazhen",//28
			"fb_yaobazhen",//29
			"fb_yaobazhen",//30
			"fb_wudouchang",//31
			"0",//32
			"0",//33
			"0",//34
			"0",//35
			"0",//36
			"0",//37
			"LoadingScene",//38
		};

		//��������
		public enum SCENE_TYPE
		{
			SCENETYPE_CLIENT = -1,    //�ͻ��˳���
			SCENETYPE_MAINCITY = 0,   //����
			SCENETYPE_WILDCITY,       //Ұ��
			SCENETYPE_COPYSCENE,      //����

			Scene_Type_NUM
		}

		public enum DAMAGEBOARD_TYPE
		{
			PLAYER_TYPE_INVALID = -1,
			PLAYER_HP_UP = 0, //�ҷ�HP����
			PLAYER_HP_DOWN, //�ҷ�HP����
			PLAYER_XP_UP, //�ҷ� XP����
			PLAYER_XP_DOWN,//�ҷ�XP ����
			PLAYER_MP_UP,//�ҷ�MP����
			PLAYER_MP_DOWN,//�ҷ�MP����
			TARGET_HPDOWN_PARTNER,//�ҷ���������Է��ȣм���
			TARGET_HPDOWN_PLAYER,//�ҷ�������ɶԷ�HP����
			PLAYER_ATTACK_MISS,//�ҷ�����ʱ δ����
			TARGET_ATTACK_MISS,//�Է�����ʱ δ����
			SKILL_NAME, //������
			PLAYER_ATTACK_CRITICAL,//�ҷ�����ʱ �������˺�
			TARGET_ATTACK_CRITICAL,//�Է�����ʱ �������˺�
			PLAYER_ATTACK_CRITICAL_PARTNER,//�ҷ���鹥��ʱ �������˺�
			PLAYER_ATTACK_IGNORE,//�ҷ�����ʱ ���˺�����
			TARGET_ATTACK_IGNORE,//�Է�����ʱ  ���˺�����
			PLAYER_ATTACK_IGNORE_PARTNER,//�ҷ���鹥��ʱ ���˺�����
			PLAYER_ATTACK_MISS_PARTNER,//�ҷ���鹥��ʱ ��δ����
			SKILL_NAME_NPC,//NPC������
		}

		public enum CAMP_DEFINE
		{
			CAMP_INVALID = -1,
			CAMP_PLAYER = 0,
			CAMP_FRIENDLY,
			CAMP_ENEMY_NORMAL,
			CAMP_ENEMY_ATTACK,
		}

		public enum ITEM_CLASS
		{
			CLASS_INVALID = -1,
			CLASS_TEST = 0,
			CLASS_MAX,
		}

		public enum ITEM_SUBCLASS
		{
			SUBCLASS_INVALID = -1,
			SUBCLASS_TEST = 0,
			SUBCLASS_MAX,
		}

		public enum MESSAGEBOX_TYPE
		{
			TYPE_INVALID = -1,
			TYPE_OK = 0,
			TYPE_OKCANCEL = 1,
			TYPE_WAIT = 2,
			TYPE_MAX,
		}

		//����б�UI����ķ�������
		public enum RELATION_TAB_TYPE
		{
			RELATION_TAB_INVALID = -1,
			RELATION_TAB_FRIEND,
			RELATION_TAB_MAIL,
			RELATION_TAB_TEAM,
		};

		//����������
		public enum STRFILTER_TYPE
		{
			STRFILTER_CHAT = 0,         //����
			STRFILTER_NAME,             //����
		}
		//��������
		public enum RELIVE_TYPE
		{
			RELIVE_ORIGINAL = 1,     //ԭ�ظ���
			RELIVE_ENTRY,           //��ڸ���
			RELIVE_CITY,            //���Ǹ���
		}

		//ʰȡ��Ʒ����
		public enum AUTOCOMBAT_PICKUP_TYPE
		{
			PICKUP_EQUIP1 = 1,//��ɫƷ��
			PICKUP_EQUIP2,//����Ʒ��
			PICKUP_EQUIP3,//����Ʒ��
			PICKUP_EQUIP4,//ʷʫƷ��
			PICKUP_EQUIP5,//����Ʒ��
			PICKUP_STUFF,//����
			PICKUP_OTHER,//����
		}

		public enum DROP_TYPE
		{
			DROP_ITEM = 1,  //��Ʒ
			DROP_COIN,      //���
		}


		//����Ṧ�켣����
		public enum QINGGONG_TRAIL_TYPE
		{
			PARABOLA,       //�����߹켣
			TURN_LEFT,      //�������Թ켣
			TURN_RIGHT,     //�������Թ켣
		}

		//�Զ��һ���Ʒ��ʼ��
		//         4011	��ҩ	��ҩ	
		//         4012	��ҩ	�컯��	
		//         4013	��ҩ	��Ѫ��	
		//         4014	��ҩ	��Ԫ��	
		//         4015	��ҩ	���ĵ�	
		//         4016	��ҩ	�󻹵�	
		//         4017	��ҩ	�ػ굤	
		//         4018	��ҩ	������	
		//         4019	��ҩ	������	
		//         4020	��ҩ	�����	
		//         4021	��ҩ	����ɢ	
		//         4022	��ҩ	����ɢ	
		//         4023	��ҩ	����ɢ	
		//         4024	��ҩ	����ɢ	
		//         4025	��ҩ	����ɢ	
		//         4026	��ҩ	����ɢ	
		//         4027	��ҩ	����ɢ	
		//         4028	��ҩ	ͨ��ɢ	
		//         4029	��ҩ	����ɢ	
		//         4030	��ҩ	����ɢ	

		public enum AUTOCOMBAT_DRUG_ID
		{
			AUTO_DRUG_START_HP = 4011,        //Ѫҩ��ʼ
			AUTO_DRUG_END_HP = 4020,        //Ѫҩ����  
			AUTO_DRUG_START_MP = 4021,        //��ҩ��ʼ
			AUTO_DRUG_END_MP = 4030,        //��ҩ����
			AUTO_DRUG_START_DYHP = 4001,    //Ѫ�׿�ʼ
			AUTO_DRUG_END_DYHP = 4005,    //Ѫ�׿�ʼ
			AUTO_DRUG_START_DYMP = 4006,    //Ѫ�׿�ʼ
			AUTO_DRUG_END_DYMP = 4010,    //Ѫ�׿�ʼ
		}

		public enum PLAYER_FIRSTSKILL
		{
			FIRSTSKILL_SHAOLIN = 10301,
			FIRSTSKILL_TIANSHAN = 20301,
			FIRSTSKILL_DALI = 30301,
			FIRSTSKILL_XIAOYAO = 40301,
		}

		//���ְλ���壬�ͷ������İ��ְλö�ٶ�Ӧ
		public enum GUILD_JOB
		{
			INVALID = -1,     //�Ƿ�
			CHIEF,            //�᳤
			VICE_CHIEF,       //���᳤
			MEMBER,           //��ͨ��Ա
			RESERVE,          //Ԥ����Ա
			MAX,
		}

		public enum NEWBUTTON_LEVEL
		{
			PARTNER = 6,
			BELLE = 10,
			AUTOFIGHT = 12,
			ACTIVITY = 12,
			EQUIPSTREN = 15,
			FARM = 20,
			GUILD = 40,
			XIAKE = 60,
		}
		public enum RANKTYPE
		{
			TYPE_CANGJINGGE = 1, //�ؾ��󸱱�
			TYPE_PRELIMINARYGUILDWARRANK = 2,//��ս��ѡ����
			TYPE_PRELIMINARYGUILDWARKILLRANK = 3,//��ս��ѡ ��ɱ��������
			TYPE_HUASHANZHANJI = 4,//��ɽ-ս��
			TYPE_HUASHANJINYAODAI = 5,//��ɽ-������
			TYPE_USERLEVELRANK = 6, //�ȼ�
			TYPE_USERCOMBATRANK = 7, //ս����
			TYPE_USERHPRANK = 8,//Ѫ��
			TYPE_GUILDCOMBAT = 9,//���ս����
			TYPE_HUASHANPOS = 10,//��ɽ-����
			TYPE_SHAOLINREPUTATION = 11, //���ִ����
			TYPE_TIANSHANREPUTATION = 12,//��ɽ�����
			TYPE_DALIREPUTATION = 13,//��������
			TYPE_XIAOYAOREPUTATION = 14,//��ң�����
			TYPE_USERCOIN = 15,//���
			TYPE_MASTER = 16,//��ʦ
			TYPE_USERCOSTYUANBAO = 17,//�������а�
			TYPE_ATTACK = 18,//���������а�
			TYPE_CHONGZHI = 19,//��ֵ���а�
			TYPE_MASTERAVTIVECOMBAT = 20,//ʦ��ս�����а�
			TYPE_SHAOSHISHAN = 21,//����ɽ���а�
			TYPE_TOTALONLINETIME = 22,//����ʱ�����а�
		}
		public enum MODELTYPE //�������
		{
			HUMAN = 1,//����
			HUMAN_FAT = 2,//����(���� ٪��)
			ANIMAL = 3,//���㶯��
			HUMAN_DYQ = 4,//����(������)
		}
		public enum TLI_COPYSCENEID
		{
			TLI_NUHAICHUJIAN = 22,   //��ͷս��
			TLI_JUXIANZHUAN = 16,   //����ׯ
			TLI_CANGJINGGE = 14,    //�ؾ���
			TLI_YANZIWU = 19,       //������
			TLI_YANWANGGUMO = 21,   //������Ĺ
			TLI_ZHENLONGQIJU = 28,  //�������
			TLI_SHAOSHISHAN = 31,   //����ɽ
									//            TLI_NUHAICHUJIAN = 7,   //��ͷս��
									//            TLI_JUXIANZHUAN = 11,   //����ׯ
									//            TLI_CANGJINGGE = 14,    //�ؾ���
									//            TLI_YANZIWU = 19,       //������
									//            TLI_YANWANGGUMO = 27,   //������Ĺ
									//            TLI_ZHENLONGQIJU = 28,  //�������
									//            TLI_SHAOSHISHAN = 31,   //����ɽ
		};
		//��������������� FORCETYPE_T����һ��
		public enum FORCETYPE
		{
			USER_NORMAL = 0,//�������
			NPC_FRINEND = 1,//�Ѻ�NPC
			NPC_NEUTRALITY = 2,//����NPC
			NPC_ATTACK = 3,//�ж�NPC(��������)
			USER_KILL = 4,//(����)
			FELLOW = 5,//���
			PVP1 = 6,//PVP ����1
			PVP2 = 7,//PVP ����2
			HELP_NPC = 8,//��սNPC ������Ҵ��
			MAX_NUM,
		}

		// ����ָ��
		public enum NEWOLAYERGUIDE
		{
			PET_GAIN = 20,      // ��ȡ��顣
			PET_FIGHT = 21,         // �̴ӳ�ս��
			EQUIP_GEM = 22,         // ��ʯ��Ƕ
			EQUIP_INTENSIFY = 23,   // װ��ǿ��
			EQUIP_START = 24,       // װ������
			MINGJIANG_QIMI = 25,            // �����������������������ܺͽ���������
			MINGJIANG_FIGHE = 26,       // ���� ����
			BAOWU = 27,             // ��������ϵͳ��ָ�����б��������
			EXITDUNGEON = 28,       // �뿪����
			ACTIVITY_MISSION = 29,  // ��ÿ�ջ����ȡһ���������񣬲���ɡ���Ҫǿ����������Ϊ��һ������
			ACTIVITY_QUNXIONG = 30,         // ���һ��Ⱥ����¹��
			ACTIVITY_QIXINGXUANZHEN = 31,       // һ����������
			ACTIVITY_HULAOGUAN = 32,    // ���һ�λ��ιء�
			ACTIVITY_WUSHENTA = 33, // ���������2�㡣
			ACTIVITY_HUSONGMEIREN = 34, // ��ɻ������˸�����
			ACTIVITY_GUOGUANZHANJIANG = 35, // ���һ�ι���ն����
			ACTIVITY_FENGHUOLIANTIAN = 36,  // ���һ�ι���ն����
			DIVI_MONEY = 37,
			DIVI_DRAW = 38,
			RESTAURANT = 39,
			COMPOUND = 40,
			GUAJI = 41,         // �һ�
			ACTIVITY_YEXIDAYIN = 42,    // ���һ�ι���ն����
			UI_CLOSE = 200,     // ����ر�
			UI_BACK = 1000,     // û��ָ��
			UI_NOGUIDE = 1001,  // û��ָ��
		}
	}
}
