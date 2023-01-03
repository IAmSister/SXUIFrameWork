
using UnityEngine;
using System.Collections;

namespace Games.GlobeDefine
{
	public class GameDefine_Globe
	{
		//打星石的commonitem中的ID
		public const int STAR_COMMONITEM_ID = 24;
		//公用特效枚举
		public enum EffectID
		{
			BEHIT = 5001,

		}
		//枚举
		public enum GAMESTATUS                  //游戏状态
		{
			GAMESTATUS_INVALID = -1,                //非法状态
			GAMESTATUS_LOGIN,                   //登录状态
			GAMESTATUS_MAIN,                    //主游戏状态
			GAMESTATUS_NUM,                     //状态总数
		}

		public enum OBJ_TYPE                    //Obj类型
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
		//NPC类别（0普通 1精英 2 BOSS）
		public enum NPC_TYPE
		{
			NORMAL = 0,//普通
			ELITE,//精英
			BOSS,//BOSS
		}
		//obj状态 相关 !!!跟服务器 ANIMATIONSTATE　保持一致
		public enum OBJ_ANIMSTATE
		{
			STATE_INVAILD = -1,
			STATE_NORMOR = 0, //待机
			STATE_WALK, //行走
			STATE_HIT,//受击
			STATE_ATTACKDOWN,//击倒
			STATE_ATTACKFLY,//击飞
			STATE_DEATH,//死亡
			STATE_HITBYSHAOLIN,//怪物受击（受到少林的普攻）
			STATE_HITBYTIANSHAN,//怪物受击（受到天山的普攻）
			STATE_HITBYDALI,//怪物受击（受到大理的普攻）
			STATE_HITBYXIAOYAO,//怪物受击（受到逍遥的普攻）
			STATE_JUMP, //跳跃
			STATE_JUMP_END,//跳跃结束
			STATE_FASTRUN_LEFT, //左倾斜快速奔跑
			STATE_FASTRUN_RIGHT, //右倾斜快速奔跑
			STATE_CORPSE,//尸体
		}
		public enum PACKET_DEFINE               //消息包类型定义，一定在最后添加
		{
		}

		public enum EVENT_DEFINE                //客户端事件，一定在最后添加
		{
			EVENT_INVALID = -1,                 // 非法事件
			EVENT_ENTERGAME,                    // 进入游戏事件
			EVENT_CHANGESCENE,                  // 切换场景
			EVENT_CONNECT_SUCCESS,              // 连接服务器成功
			EVENT_CONNECT_FAIL,                 // 连接服务器失败
			EVENT_MISSION_COLLECTITEM,          // 采集任务 直接跑到了采集
			EVENT_COLLECTITEM_RESEED,           // 采集点 刷新

			EVENT_QINGGONG,                     // 客户端轻功
		}

		public enum SCENE_DEFINE
		{
			SCENE_WUSHENTA = 20,           // 武神塔 藏经阁
			SCENE_QIXINGXUANZHEN = 28,           // 七星玄镇 珍珑棋局
			SCENE_TIANXIAWUSHUANG = 23,           // 天下无双 华山论剑
			SCENE_HULAOGUAN = 16,           // 虎牢关 聚贤庄
			SCENE_HUSONGMEIREN = 19,           // 护送美人  燕子坞
			SCENE_FENGHUOLIANTIAN = 31,           // 烽火连天 副本少室山
			SCENE_GUILDWAR = 11,           // 帮战副本
			SCENE_YEXIDAYING = 21,           // 夜袭大营 燕王古墓
			SCENE_WORLDBOSS = 35,           // 世界BOSS
			SCENE_GUOGUANZHANJIANG = 22,           // 过关斩将 怒海锄奸 虎头战船
			SCENE_RICHANGJUEDOU = 17,           // 日常决斗
			SCENE_LOGIN = 0,            // 登录
			SCENE_ERHAI = 1,            // 洱海
			SCENE_SHAOSHISHAN = 2,            // 少室山
			SCENE_LOADINGSCENE = 38,            // loading
			SCENE_TIANSHAN = 4,            // 天山
			SCENE_XINGZILIN = 5,            // 杏子林
			SCENE_JIANHUGONG = 6,            // 剑湖宫
			SCENE_WUDAOZHIDIAN = 8,            // 武道之巅副本，暂时为临时资源                                 
			SCENE_XIAOJINGHU = 9,            // 小镜湖
			SCENE_YUQINGGONG = 10,           // 玉清宫
			SCENE_YANMENGUANWAI = 13,           // 雁门关外
			SCENE_SUZHOU = 12,           // 苏州
			SCENE_WANGYOUGU = 18,           // 忘忧谷 副本任务通用场景
			SCENE_JIANYU = 32,           // 监狱
			SCENE_WUCHANG = 33,           // 武场
		}

		/// <summary>
		/// 场景默认高度。对应的Index 和 SCENE_DEFINE中value (或SceneName 的Index)对应
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

		//场景类型
		public enum SCENE_TYPE
		{
			SCENETYPE_CLIENT = -1,    //客户端场景
			SCENETYPE_MAINCITY = 0,   //主城
			SCENETYPE_WILDCITY,       //野外
			SCENETYPE_COPYSCENE,      //副本

			Scene_Type_NUM
		}

		public enum DAMAGEBOARD_TYPE
		{
			PLAYER_TYPE_INVALID = -1,
			PLAYER_HP_UP = 0, //我方HP增加
			PLAYER_HP_DOWN, //我方HP减少
			PLAYER_XP_UP, //我方 XP增加
			PLAYER_XP_DOWN,//我方XP 减少
			PLAYER_MP_UP,//我方MP增加
			PLAYER_MP_DOWN,//我方MP减少
			TARGET_HPDOWN_PARTNER,//我方伙伴早曾对方ＨＰ减少
			TARGET_HPDOWN_PLAYER,//我方主角造成对方HP减少
			PLAYER_ATTACK_MISS,//我方攻击时 未命中
			TARGET_ATTACK_MISS,//对方攻击时 未命中
			SKILL_NAME, //技能名
			PLAYER_ATTACK_CRITICAL,//我方攻击时 出暴击伤害
			TARGET_ATTACK_CRITICAL,//对方攻击时 出暴击伤害
			PLAYER_ATTACK_CRITICAL_PARTNER,//我方伙伴攻击时 出暴击伤害
			PLAYER_ATTACK_IGNORE,//我方攻击时 出伤害免疫
			TARGET_ATTACK_IGNORE,//对方攻击时  出伤害免疫
			PLAYER_ATTACK_IGNORE_PARTNER,//我方伙伴攻击时 出伤害免疫
			PLAYER_ATTACK_MISS_PARTNER,//我方伙伴攻击时 出未命中
			SKILL_NAME_NPC,//NPC技能名
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

		//玩家列表UI界面的分类类型
		public enum RELATION_TAB_TYPE
		{
			RELATION_TAB_INVALID = -1,
			RELATION_TAB_FRIEND,
			RELATION_TAB_MAIL,
			RELATION_TAB_TEAM,
		};

		//过滤字类型
		public enum STRFILTER_TYPE
		{
			STRFILTER_CHAT = 0,         //聊天
			STRFILTER_NAME,             //命名
		}
		//复活类型
		public enum RELIVE_TYPE
		{
			RELIVE_ORIGINAL = 1,     //原地复活
			RELIVE_ENTRY,           //入口复活
			RELIVE_CITY,            //主城复活
		}

		//拾取物品类型
		public enum AUTOCOMBAT_PICKUP_TYPE
		{
			PICKUP_EQUIP1 = 1,//白色品质
			PICKUP_EQUIP2,//优秀品质
			PICKUP_EQUIP3,//精良品质
			PICKUP_EQUIP4,//史诗品质
			PICKUP_EQUIP5,//创奇品质
			PICKUP_STUFF,//材料
			PICKUP_OTHER,//其他
		}

		public enum DROP_TYPE
		{
			DROP_ITEM = 1,  //物品
			DROP_COIN,      //金币
		}


		//玩家轻功轨迹类型
		public enum QINGGONG_TRAIL_TYPE
		{
			PARABOLA,       //抛物线轨迹
			TURN_LEFT,      //左倾线性轨迹
			TURN_RIGHT,     //右倾线性轨迹
		}

		//自动挂机物品初始化
		//         4011	红药	金创药	
		//         4012	红药	造化丹	
		//         4013	红药	凝血丹	
		//         4014	红药	混元丹	
		//         4015	红药	保心丹	
		//         4016	红药	大还丹	
		//         4017	红药	回魂丹	
		//         4018	红药	重生丹	
		//         4019	红药	代赭丹	
		//         4020	红药	朱哈丹	
		//         4021	蓝药	回气散	
		//         4022	蓝药	理气散	
		//         4023	蓝药	凝气散	
		//         4024	蓝药	纳气散	
		//         4025	蓝药	气定散	
		//         4026	蓝药	定神散	
		//         4027	蓝药	清灵散	
		//         4028	蓝药	通灵散	
		//         4029	蓝药	龙葵散	
		//         4030	蓝药	冰蚕散	

		public enum AUTOCOMBAT_DRUG_ID
		{
			AUTO_DRUG_START_HP = 4011,        //血药开始
			AUTO_DRUG_END_HP = 4020,        //血药结束  
			AUTO_DRUG_START_MP = 4021,        //蓝药开始
			AUTO_DRUG_END_MP = 4030,        //蓝药结束
			AUTO_DRUG_START_DYHP = 4001,    //血缸开始
			AUTO_DRUG_END_DYHP = 4005,    //血缸开始
			AUTO_DRUG_START_DYMP = 4006,    //血缸开始
			AUTO_DRUG_END_DYMP = 4010,    //血缸开始
		}

		public enum PLAYER_FIRSTSKILL
		{
			FIRSTSKILL_SHAOLIN = 10301,
			FIRSTSKILL_TIANSHAN = 20301,
			FIRSTSKILL_DALI = 30301,
			FIRSTSKILL_XIAOYAO = 40301,
		}

		//帮会职位定义，和服务器的帮会职位枚举对应
		public enum GUILD_JOB
		{
			INVALID = -1,     //非法
			CHIEF,            //会长
			VICE_CHIEF,       //副会长
			MEMBER,           //普通会员
			RESERVE,          //预备会员
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
			TYPE_CANGJINGGE = 1, //藏经阁副本
			TYPE_PRELIMINARYGUILDWARRANK = 2,//帮战海选排行
			TYPE_PRELIMINARYGUILDWARKILLRANK = 3,//帮战海选 击杀人数排行
			TYPE_HUASHANZHANJI = 4,//华山-战绩
			TYPE_HUASHANJINYAODAI = 5,//华山-金腰带
			TYPE_USERLEVELRANK = 6, //等级
			TYPE_USERCOMBATRANK = 7, //战斗力
			TYPE_USERHPRANK = 8,//血量
			TYPE_GUILDCOMBAT = 9,//帮会战斗力
			TYPE_HUASHANPOS = 10,//华山-排名
			TYPE_SHAOLINREPUTATION = 11, //少林大弟子
			TYPE_TIANSHANREPUTATION = 12,//天山大弟子
			TYPE_DALIREPUTATION = 13,//大理大弟子
			TYPE_XIAOYAOREPUTATION = 14,//逍遥大弟子
			TYPE_USERCOIN = 15,//金币
			TYPE_MASTER = 16,//宗师
			TYPE_USERCOSTYUANBAO = 17,//消费排行榜
			TYPE_ATTACK = 18,//攻击力排行榜
			TYPE_CHONGZHI = 19,//充值排行榜
			TYPE_MASTERAVTIVECOMBAT = 20,//师门战力排行榜
			TYPE_SHAOSHISHAN = 21,//少室山排行榜
			TYPE_TOTALONLINETIME = 22,//在线时间排行榜
		}
		public enum MODELTYPE //骨骼类别
		{
			HUMAN = 1,//人形
			HUMAN_FAT = 2,//人形(胖子 侏儒)
			ANIMAL = 3,//四足动物
			HUMAN_DYQ = 4,//人形(段延庆)
		}
		public enum TLI_COPYSCENEID
		{
			TLI_NUHAICHUJIAN = 22,   //虎头战船
			TLI_JUXIANZHUAN = 16,   //聚贤庄
			TLI_CANGJINGGE = 14,    //藏经阁
			TLI_YANZIWU = 19,       //燕子坞
			TLI_YANWANGGUMO = 21,   //燕王古墓
			TLI_ZHENLONGQIJU = 28,  //珍珑棋局
			TLI_SHAOSHISHAN = 31,   //少室山
									//            TLI_NUHAICHUJIAN = 7,   //虎头战船
									//            TLI_JUXIANZHUAN = 11,   //聚贤庄
									//            TLI_CANGJINGGE = 14,    //藏经阁
									//            TLI_YANZIWU = 19,       //燕子坞
									//            TLI_YANWANGGUMO = 27,   //燕王古墓
									//            TLI_ZHENLONGQIJU = 28,  //珍珑棋局
									//            TLI_SHAOSHISHAN = 31,   //少室山
		};
		//！！！！与服务器 FORCETYPE_T保持一致
		public enum FORCETYPE
		{
			USER_NORMAL = 0,//玩家势力
			NPC_FRINEND = 1,//友好NPC
			NPC_NEUTRALITY = 2,//中立NPC
			NPC_ATTACK = 3,//敌对NPC(主动攻击)
			USER_KILL = 4,//(废弃)
			FELLOW = 5,//伙伴
			PVP1 = 6,//PVP 势力1
			PVP2 = 7,//PVP 势力2
			HELP_NPC = 8,//助战NPC 帮助玩家打怪
			MAX_NUM,
		}

		// 新手指引
		public enum NEWOLAYERGUIDE
		{
			PET_GAIN = 20,      // 抽取伙伴。
			PET_FIGHT = 21,         // 侍从出战。
			EQUIP_GEM = 22,         // 宝石镶嵌
			EQUIP_INTENSIFY = 23,   // 装备强化
			EQUIP_START = 24,       // 装备打星
			MINGJIANG_QIMI = 25,            // 开启名将，对名将进行亲密和进化操作。
			MINGJIANG_FIGHE = 26,       // 名将 上阵
			BAOWU = 27,             // 开启宝物系统，指引进行宝物操作。
			EXITDUNGEON = 28,       // 离开副本
			ACTIVITY_MISSION = 29,  // 在每日活动中领取一个门派任务，并完成。需要强制门派任务为第一个任务。
			ACTIVITY_QUNXIONG = 30,         // 完成一次群雄逐鹿。
			ACTIVITY_QIXINGXUANZHEN = 31,       // 一次七星玄阵。
			ACTIVITY_HULAOGUAN = 32,    // 完成一次虎牢关。
			ACTIVITY_WUSHENTA = 33, // 完成武神塔2层。
			ACTIVITY_HUSONGMEIREN = 34, // 完成护送美人副本。
			ACTIVITY_GUOGUANZHANJIANG = 35, // 完成一次过关斩将。
			ACTIVITY_FENGHUOLIANTIAN = 36,  // 完成一次过关斩将。
			DIVI_MONEY = 37,
			DIVI_DRAW = 38,
			RESTAURANT = 39,
			COMPOUND = 40,
			GUAJI = 41,         // 挂机
			ACTIVITY_YEXIDAYIN = 42,    // 完成一次过关斩将。
			UI_CLOSE = 200,     // 界面关闭
			UI_BACK = 1000,     // 没有指引
			UI_NOGUIDE = 1001,  // 没有指引
		}
	}
}
