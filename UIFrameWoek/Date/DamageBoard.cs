
using UnityEngine;
using System.Collections;
using Games.GlobeDefine;
using GCGame.Table;
using System.Collections.Generic;
using GCGame;
public class DamageBoard : MonoBehaviour
{
    #region old
    private Transform m_DamageBoardRootTransform;    //����GameObject��Transform

    private UniformAcceleratedMotion m_UAMotion;     //UA
    private TweenScale m_TweenScalePlus;             //����
    private TweenScale m_TweenScaleMinus;            //����

    private float m_ShowTime = 0.0f;                //��ʾʱ��
    public float ShowTime
    {
        get { return m_ShowTime; }
        set { m_ShowTime = value; }
    }
    #endregion


    public List<UISprite> sprites = new List<UISprite>();

    //����Sprite GameObject
    void allocSprite(int number)
    {
        for (int i = 0; i < sprites.Count; i++)
        {
            if (number <= 0)
            {
                sprites[i].gameObject.SetActive(false);
            }
            else if (!sprites[i].gameObject.activeSelf)
            {
                sprites[i].gameObject.SetActive(true);
            }
           // Utils.ZeroTrans(sprites[i].gameObject);
            number--;
        }
        for (int ni = 0; ni < number; ni++)
        {
            GameObject newObj = NGUITools.AddChild(gameObject, sprites[0].gameObject);
            sprites.Add(newObj.GetComponent<UISprite>());
        }
    }
    //����ͼƬ����λ�ú�����
    void setSpriteNumber(string strNumber, string picHead, Vector3 originPos, string firstName = "")
    {
        int i = 0;
        int ni = 0;
        float xPos = 0;
        int len = strNumber.Length;
        //��������.
        if (firstName != "")
        {
            sprites[i].spriteName = firstName;
            sprites[i].MakePixelPerfect();
            sprites[i].transform.localPosition = originPos;
            xPos += sprites[i].width * 0.5f;
            i++;
            len++;

        }
        //setPosition
        for (; i < len; i++)
        {
            sprites[i].spriteName = picHead + "_" + strNumber[ni].ToString();
            sprites[i].MakePixelPerfect();
            sprites[i].transform.localPosition = new Vector3(sprites[i].transform.localPosition.x + xPos, 0, 0);
            sprites[i].transform.localPosition += originPos;
            sprites[i].transform.localScale *= 1.5f;
            xPos += 32;
            ni++;
        }
    }
    public void ShowDamageBoardNumber(GameDefine_Globe.DAMAGEBOARD_TYPE typ, string strNumber)
    {
        //Tab_DamageBoardType tabDamageBoardType = DamageBoardManager.DamageBoardType[(int)typ][0];
        switch (typ)
        {
            //δ����
            case Games.GlobeDefine.GameDefine_Globe.DAMAGEBOARD_TYPE.PLAYER_ATTACK_MISS:
            case Games.GlobeDefine.GameDefine_Globe.DAMAGEBOARD_TYPE.PLAYER_ATTACK_MISS_PARTNER:
            case Games.GlobeDefine.GameDefine_Globe.DAMAGEBOARD_TYPE.TARGET_ATTACK_MISS:
                allocSprite(1);
                //sprites[0].spriteName = tabDamageBoardType.PicType;
                //sprites[0].transform.localPosition = new Vector3(tabDamageBoardType.OriginX, tabDamageBoardType.OriginY, 0);
                sprites[0].MakePixelPerfect();
                break;
            //����
            case Games.GlobeDefine.GameDefine_Globe.DAMAGEBOARD_TYPE.PLAYER_ATTACK_IGNORE:
            case Games.GlobeDefine.GameDefine_Globe.DAMAGEBOARD_TYPE.PLAYER_ATTACK_IGNORE_PARTNER:
            case Games.GlobeDefine.GameDefine_Globe.DAMAGEBOARD_TYPE.TARGET_ATTACK_IGNORE:
                allocSprite(1);
                //sprites[0].spriteName = tabDamageBoardType.PicType;
                //sprites[0].transform.localPosition = new Vector3(tabDamageBoardType.OriginX, tabDamageBoardType.OriginY, 0);
                sprites[0].MakePixelPerfect();
                break;
            //����.
            case Games.GlobeDefine.GameDefine_Globe.DAMAGEBOARD_TYPE.PLAYER_ATTACK_CRITICAL:
            case Games.GlobeDefine.GameDefine_Globe.DAMAGEBOARD_TYPE.PLAYER_ATTACK_CRITICAL_PARTNER:
            case Games.GlobeDefine.GameDefine_Globe.DAMAGEBOARD_TYPE.TARGET_ATTACK_CRITICAL:
                allocSprite(strNumber.Length + 1);

               // setSpriteNumber(strNumber, tabDamageBoardType.PicType.Split('_')[0], new Vector3(tabDamageBoardType.OriginX, tabDamageBoardType.OriginY, 0), tabDamageBoardType.PicType);
                break;
            //��ͨ��Ѫ
            case Games.GlobeDefine.GameDefine_Globe.DAMAGEBOARD_TYPE.PLAYER_HP_DOWN:
            case Games.GlobeDefine.GameDefine_Globe.DAMAGEBOARD_TYPE.PLAYER_HP_UP:
            case Games.GlobeDefine.GameDefine_Globe.DAMAGEBOARD_TYPE.PLAYER_MP_DOWN:
            case Games.GlobeDefine.GameDefine_Globe.DAMAGEBOARD_TYPE.PLAYER_MP_UP:
            case Games.GlobeDefine.GameDefine_Globe.DAMAGEBOARD_TYPE.PLAYER_TYPE_INVALID:
            case Games.GlobeDefine.GameDefine_Globe.DAMAGEBOARD_TYPE.PLAYER_XP_DOWN:
            case Games.GlobeDefine.GameDefine_Globe.DAMAGEBOARD_TYPE.PLAYER_XP_UP:
            case Games.GlobeDefine.GameDefine_Globe.DAMAGEBOARD_TYPE.TARGET_HPDOWN_PARTNER:
            case Games.GlobeDefine.GameDefine_Globe.DAMAGEBOARD_TYPE.TARGET_HPDOWN_PLAYER:
                allocSprite(strNumber.Length);
               // setSpriteNumber(strNumber, tabDamageBoardType.PicType, new Vector3(tabDamageBoardType.OriginX, tabDamageBoardType.OriginY, 0));
                break;
        }
    }
    //public void ShowDamageBoradSkill(Tab_DamageBoardType tabDamage, string sprName)
    //{
    //    allocSprite(1);
    //    sprites[0].spriteName = sprName;
    //    sprites[0].MakePixelPerfect();
    //    Utils.ZeroTrans(sprites[0].gameObject);
    //    sprites[0].transform.localPosition = new Vector3(tabDamage.OriginX, tabDamage.OriginY, 0);
    //}

    #region old
    public void Awake()
    {
        if (null == m_DamageBoardRootTransform)
        {
            m_DamageBoardRootTransform = gameObject.transform;
        }



        if (null == m_UAMotion)
        {
            m_UAMotion = gameObject.AddComponent<UniformAcceleratedMotion>();
        }

        if (null == m_TweenScalePlus)
        {
            m_TweenScalePlus = gameObject.AddComponent<TweenScale>();
        }

        if (null == m_TweenScaleMinus)
        {
            m_TweenScaleMinus = gameObject.AddComponent<TweenScale>();
        }
    }

    public void Reuse(Vector3 position)
    {

        gameObject.SetActive(true);

    }

    public void Remove()
    {
        gameObject.SetActive(false);
    }
    #endregion

    //�ڴ������߸�����ɺ󣬵��øýӿڣ���ʾ�˺���Ϣ
    public bool ActiveDamageBoard(int nType, string strValue, Vector3 pos, bool isPlayerSkill = true)
    {
       // Tab_DamageBoardType tabDamageBoardType = DamageBoardManager.DamageBoardType[nType][0];
        //if (tabDamageBoardType == null)
        //{
        //    //tabDamageBoardType = DamageBoardManager.DamageBoardType[0][0];
        //}
        //��ʼ���˺���
        if (isPlayerSkill)
        {
           // ShowDamageBoradSkill(tabDamageBoardType, strValue);
        }
        else
        {
            ShowDamageBoardNumber((GameDefine_Globe.DAMAGEBOARD_TYPE)nType, strValue);
        }


        // ��ȡ�����͵ı���� 
        // ��ʼλ�� ���ٶ� ���ٶ�
        //Vector3 vecOrigin = new Vector3(tabDamageBoardType.OriginX, tabDamageBoardType.OriginY, 0);
        //Vector3 vecVelocity = new Vector3(tabDamageBoardType.VelocityX, tabDamageBoardType.VelocityY, 0);
        //Vector3 vecAcceleration = new Vector3(tabDamageBoardType.AccelerationX, tabDamageBoardType.AccelerationY, 0);
        //float fShowTime = tabDamageBoardType.ShowTime;              // ������ʾʱ��
        //float fFadeTime = tabDamageBoardType.FadeTime;               // ������ʧʱ��
        //float fMotionTime = fShowTime + fFadeTime;                       // ���˶�ʱ��
        //string strTextColor = tabDamageBoardType.TextColor;          // ������ɫ
        ////string strOutlineColor = tabDamageBoardType.OutlineColor;   // �����ɫ
        //float fTextSize = tabDamageBoardType.TextSize;                // ���ִ�С
        //float fScaleDelayTime = tabDamageBoardType.ScaleDelayTime;     // �ߴ�仯�ӳ�ʱ��
        //float fTextSizeMax = tabDamageBoardType.TextSizeMax;            // ���ߴ�
        //float fScalePlusTime = tabDamageBoardType.ScalePlusTime;          // �Ŵ�ʱ��
        //float fTextSizeOver = tabDamageBoardType.TextSizeOver;          // �����ߴ�
        //float fScaleMinusTime = tabDamageBoardType.ScaleMinusTime;    // ��Сʱ��

        if (null == m_DamageBoardRootTransform)
        {
            m_DamageBoardRootTransform = gameObject.transform;
        }

        if (null == m_UAMotion)
        {
            m_UAMotion = gameObject.AddComponent<UniformAcceleratedMotion>();
        }

        if (null == m_TweenScalePlus)
        {
            m_TweenScalePlus = gameObject.AddComponent<TweenScale>();
        }

        if (null == m_TweenScaleMinus)
        {
            m_TweenScaleMinus = gameObject.AddComponent<TweenScale>();
        }

        // ʹ�þɵ�TweenAlpha��ҪReset
        //m_TweenScalePlus.Reset();
        //m_TweenScaleMinus.Reset();

        // ����Label�ؼ�
        //         string strText = "[" + strTextColor + "]";
        //         strText += strValue;
        //         m_DamageBoardLabel.text = strText;

        //damageBoardLabel.effectColor = Utils.GetColorByString(strOutlineColor);

        // �ȱ����˶� ������ٶ� ���ٶ� �˶�ʱ��
       // m_UAMotion.Init(vecVelocity, vecAcceleration, fMotionTime);

        // TweenScale����
        //m_TweenScalePlus.from = fTextSize * Vector3.one;
        //m_TweenScalePlus.to = fTextSizeMax * Vector3.one;
        //m_TweenScalePlus.delay = fScaleDelayTime;
        //m_TweenScalePlus.duration = fScalePlusTime;

        //m_TweenScaleMinus.from = fTextSizeMax * Vector3.one;
        //m_TweenScaleMinus.to = fTextSizeOver * Vector3.one;
        //m_TweenScaleMinus.delay = fScalePlusTime;
        //m_TweenScaleMinus.duration = fScaleMinusTime;

        // ����������ʼ����
        m_UAMotion.Go();
        //if (fScaleDelayTime >= 0 && fTextSizeMax > 0 && fScalePlusTime >= 0 && fTextSizeOver > 0 && fScaleMinusTime >= 0)
        //{
        //    m_TweenScalePlus.enabled = true;
        //    m_TweenScaleMinus.enabled = true;
        //    m_TweenScalePlus.Play();
        //    m_TweenScaleMinus.Play();
        //}
        //else
        //{
        //    m_TweenScalePlus.enabled = false;
        //    m_TweenScaleMinus.enabled = false;
        //}

        //  �������λ�� ��С
        //Add by Lijia,�˺����ָ߶�ͳһ����2.0������������Ժ����з�2.0���������������Э��
        pos.y += 2.0f;
        m_DamageBoardRootTransform.position = pos;
       // m_DamageBoardRootTransform.localScale = fTextSize * Vector3.one;
        m_DamageBoardRootTransform.localRotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);

        //�˺�������ǰ�����
        Vector3 vecUp = Camera.main.transform.rotation * Vector3.up;
        m_DamageBoardRootTransform.LookAt(m_DamageBoardRootTransform.position + Camera.main.transform.rotation * Vector3.back, vecUp);
        m_DamageBoardRootTransform.Rotate(Vector3.up * 180);

        ShowTime = Time.time;
        return true;
    }


}