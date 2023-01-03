using System;
using System.Collections.Generic;
using GCGame.Table;
using UnityEngine;
using Games.GlobeDefine;
//using Module.Log;
namespace Games.LogicObj
{
    public class Obj : MonoBehaviour
    {
        public Obj()
        {
            m_ObjType = GameDefine_Globe.OBJ_TYPE.OBJ;
        }

        void Awake()
        {
            m_ObjTransform = transform;
        }


        public GameDefine_Globe.OBJ_TYPE m_ObjType;  //Obj����
        private Shader m_OldShader = null;

        public GameDefine_Globe.OBJ_TYPE ObjType
        {
            get { return m_ObjType; }
        }
        protected bool m_bCanLogic = false;             //�Ƿ���Խ����߼�����
        public bool CanLogic
        {
            get { return m_bCanLogic; }
            set { m_bCanLogic = value; }
        }

        protected int m_ServerID;                       //Obj��ServerID
        public int ServerID
        {
            get { return m_ServerID; }
            set { m_ServerID = value; }
        }

        protected int m_ModelID;                        //Obj��ģ��ID,��CharModel���ж���
        public int ModelID
        {
            get { return m_ModelID; }
            set { m_ModelID = value; }
        }

        private GameObject m_ModelNode = null;           //�ݴ�Model�ڵ�
        public UnityEngine.GameObject ModelNode
        {
            get { return m_ModelNode; }
            set { m_ModelNode = value; }
        }
        //////////////////////////////////////////////////////////////////////////
        //���û����������Խӿ�
        //////////////////////////////////////////////////////////////////////////
        protected Transform m_ObjTransform = null;        //����Transform���������Ч��,������Awake��ʱ��ͽ��и�ֵ
        public Transform ObjTransform
        {
            get { return m_ObjTransform; }
        }
        public Vector3 Position
        {
            get { return m_ObjTransform.localPosition; }
            set
            {
                //value.y = 0;
                m_ObjTransform.localPosition = value;
            }
        }
        public Quaternion Rotation
        {
            get { return m_ObjTransform.localRotation; }
            set { m_ObjTransform.localRotation = value; }
        }
        public Vector3 Scale
        {
            get { return m_ObjTransform.localScale; }
            set { m_ObjTransform.localScale = value; }
        }
        public string GameObjectName
        {
            get { return this.gameObject.name; }
            set { this.gameObject.name = value; }
        }


        public void SetScale(float fScale)
        {
            if (null != this.gameObject)
            {
                m_ObjTransform.localScale = Vector3.one * fScale;
            }
        }

        //�ж������Ƿ����Լ�ǰ��
        public bool IsInFront(Obj targetObj)
        {
            if (null == targetObj)
            {
                return false;
            }

            //��ôӵ�ǰObj��Ŀ��Obj�ķ���Ȼ����͵�ǰObj�ĳ���нǡ�
            Vector2 tarPos = new Vector2(targetObj.ObjTransform.position.x, targetObj.ObjTransform.position.z);
            Vector2 myPos = new Vector2(ObjTransform.position.x, ObjTransform.position.z);
            Vector2 mydir = new Vector2(ObjTransform.forward.x, ObjTransform.forward.z);
            Vector2 dir = tarPos - myPos;
            float angle = Vector2.Angle(mydir.normalized, dir.normalized);
            if (angle < 90.0f)
            {
                return true;
            }

            return false;
        }

        #region ����
        ///////////////////////////////////////////////////////////////////////////////
        //�������
        ///////////////////////////////////////////////////////////////////////////////
        protected List<Material> m_WeaponMaterialList = new List<Material>();//!!!��������������Ϣ ʹ��ǰ�ǵ��пշ�ֹ���ֶ�ʧ�����
        protected List<Material> m_BodyMaterialList = new List<Material>();//!!!�������������Ϣ ʹ��ǰ�ǵ��пշ�ֹ���ֶ�ʧ�����
        protected Dictionary<string, Color> m_BodyInitColorDic = new Dictionary<string, Color>(); //!!!����������ʵ���ɫ ʹ��ǰ�ǵ��пշ�ֹ���ֶ�ʧ�����
        protected Dictionary<string, Color> m_WeaponInitColorDic = new Dictionary<string, Color>(); //!!!�����������ʵ���ɫ ʹ��ǰ�ǵ��пշ�ֹ���ֶ�ʧ�����
        protected Dictionary<string, Shader> m_BodyInitShaderDic = new Dictionary<string, Shader>(); //!!!����������ʵ�shader ʹ��ǰ�ǵ��пշ�ֹ���ֶ�ʧ�����
        protected Dictionary<string, Shader> m_WeaponInitShaderDic = new Dictionary<string, Shader>(); //!!!�����������ʵ�shader ʹ��ǰ�ǵ��пշ�ֹ���ֶ�ʧ�����
        protected bool m_bIsPlayDissolve = false;//�Ƿ�ʼ�����ܽ�Ч��
        protected float m_fPlayDissolveSpeed = 2.0f;//�Ƿ�ʼ�����ܽ�Ч��
        protected float m_fPlayDissolveDelay = 0.5f;//�ӳ�ʱ��
        protected bool m_bIsPlayUnDissolve = false;//�Ƿ�ʼ���ŷ��ܽ�Ч��
        protected float m_fPlayUnDissolveSpeed = 2.0f;//�Ƿ�ʼ�����ܽ�Ч��
        protected float m_fPlayUnDissolveDelay = 0.5f;//�ӳ�ʱ��
        public void InitMaterialInfo()
        {

            m_BodyMaterialList.Clear();
            m_WeaponMaterialList.Clear();
            m_BodyInitColorDic.Clear();
            m_WeaponInitColorDic.Clear();
            m_BodyInitShaderDic.Clear();
            m_WeaponInitShaderDic.Clear();
            m_bIsPlayDissolve = false;
            Transform _modleTransform = gameObject.transform.Find("Model");
            if (_modleTransform == null)
            {
                return;
            }
            GameObject _modle = _modleTransform.gameObject;
            if (_modle != null)
            {
                Renderer[] renderers = _modle.GetComponentsInChildren<Renderer>();
                if (renderers != null)
                {
                    for (int i = 0; i < renderers.Length; ++i)
                    {
                        if (null != renderers[i] && null != renderers[i].material)
                        {
                            //���岿��
                            if (IsBodyRenderer(renderers[i]) && m_BodyMaterialList.Contains(renderers[i].material) == false)
                            {
                                //���������Ϣ
                                m_BodyMaterialList.Add(renderers[i].material);
                                //���������ɫ��Ϣ
                                if (renderers[i].material.HasProperty("_Color") && m_BodyInitColorDic.ContainsKey(renderers[i].material.name) == false)
                                {
                                    m_BodyInitColorDic.Add(renderers[i].material.name, renderers[i].material.GetColor("_Color"));
                                }
                                //�������shader��Ϣ
                                if (m_BodyInitShaderDic.ContainsKey(renderers[i].material.name) == false)
                                {
                                    m_BodyInitShaderDic.Add(renderers[i].material.name, renderers[i].material.shader);
                                }
                            }
                            //��������
                            if (IsWeaponRenderer(renderers[i]) && m_WeaponMaterialList.Contains(renderers[i].material) == false)
                            {
                                m_WeaponMaterialList.Add(renderers[i].material);
                                //���������ɫ��Ϣ
                                if (renderers[i].material.HasProperty("_Color") && m_WeaponInitColorDic.ContainsKey(renderers[i].material.name) == false)
                                {
                                    m_WeaponInitColorDic.Add(renderers[i].material.name, renderers[i].material.GetColor("_Color"));
                                }
                                //�������shader��Ϣ
                                if (m_WeaponInitShaderDic.ContainsKey(renderers[i].material.name) == false)
                                {
                                    m_WeaponInitShaderDic.Add(renderers[i].material.name, renderers[i].material.shader);
                                }
                            }
                        }
                    }
                    OptAfterInitMaterialInfo();
                    m_OldShader = Shader.Find(m_BodyMaterialList[0].shader.name);
                }
            }
        }
        public void InitWeaponMaterialInfo()
        {
            m_WeaponMaterialList.Clear();
            m_WeaponInitColorDic.Clear();
            m_WeaponInitShaderDic.Clear();
            m_bIsPlayDissolve = false;
            Transform _modleTransform = gameObject.transform.Find("Model");
            if (_modleTransform == null)
            {
                return;
            }
            GameObject _modle = _modleTransform.gameObject;
            if (_modle != null)
            {
                Renderer[] renderers = _modle.GetComponentsInChildren<Renderer>();
                if (renderers != null)
                {
                    for (int i = 0; i < renderers.Length; ++i)
                    {
                        if (null != renderers[i] && null != renderers[i].material)
                        {
                            //��������
                            if (IsWeaponRenderer(renderers[i]) && m_WeaponMaterialList.Contains(renderers[i].material) == false)
                            {
                                //���������Ϣ
                                m_WeaponMaterialList.Add(renderers[i].material);
                                //���������ɫ��Ϣ
                                if (renderers[i].material.HasProperty("_Color") && m_WeaponInitColorDic.ContainsKey(renderers[i].material.name) == false)
                                {
                                    m_WeaponInitColorDic.Add(renderers[i].material.name, renderers[i].material.GetColor("_Color"));
                                }
                                //�������shader��Ϣ
                                if (m_WeaponInitShaderDic.ContainsKey(renderers[i].material.name) == false)
                                {
                                    m_WeaponInitShaderDic.Add(renderers[i].material.name, renderers[i].material.shader);
                                }
                            }
                        }
                    }
                    //  OptAfterInitMaterialInfo();
                }
            }
        }
        public virtual void OptAfterInitMaterialInfo()
        {
            //�б�ɫ�Ļ� ��װ�ü���
            //if (ObjEffectLogic != null && ObjEffectLogic.IsHaveChangeColorEffct())
            //{
            //    SetMaterialColor(GlobeVar.BLUEMATERIAL_R, GlobeVar.BLUEMATERIAL_G, GlobeVar.BLUEMATERIAL_B);
            //}
        }
        public bool IsBodyRenderer(Renderer _Renderer)
        {
            if (_Renderer && _Renderer.transform.parent)
            {
                if (_Renderer.transform.parent.name == "Model")
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsWeaponRenderer(Renderer _Renderer)
        {
            if (_Renderer && _Renderer.transform.parent)
            {
                //if (_Renderer.transform.parent.name == "Weapon_L" ||
                //   _Renderer.transform.parent.name == "Weapon_R")
                if (_Renderer.transform.parent.name == "HH_weaponHandLf" ||
                    _Renderer.transform.parent.name == "HH_weaponHandRt")
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
        #region ���ʱ�ɫ
        //����Ϊ��ʼ��ɫ
        public void SetMaterialInitColor()
        {
            Material _material = null;
            //�滻�������
            for (int i = 0; i < m_BodyMaterialList.Count; ++i)
            {
                _material = m_BodyMaterialList[i];
                if (null != _material)
                {
                    if (_material.HasProperty("_Color") && m_BodyInitColorDic.ContainsKey(_material.name))
                    {
                        Color _initcolor = m_BodyInitColorDic[_material.name];
                        SetMaterialColor(_material, _initcolor.r, _initcolor.g, _initcolor.b);
                    }
                }
            }
            //�滻��������
            for (int i = 0; i < m_WeaponMaterialList.Count; ++i)
            {
                _material = m_WeaponMaterialList[i];
                if (null != _material)
                {
                    if (_material.HasProperty("_Color") && m_WeaponInitColorDic.ContainsKey(_material.name))
                    {
                        Color _initcolor = m_WeaponInitColorDic[_material.name];
                        SetMaterialColor(_material, _initcolor.r, _initcolor.g, _initcolor.b);
                    }
                }
            }
        }

        //����ģ�Ͳ�����ɫ
        public void SetMaterialColor(Material _material, float red, float green, float blue)
        {
            if (_material && _material.HasProperty("_Color"))
            {
                Color c = _material.GetColor("_Color");
                c.r = red;
                c.g = green;
                c.b = blue;
                _material.color = c;
            }
        }
        //����ģ�Ͳ�����ɫ
        public void SetMaterialColor(float red, float green, float blue)
        {
            Material _material = null;
            //�滻�������
            for (int i = 0; i < m_BodyMaterialList.Count; ++i)
            {
                _material = m_BodyMaterialList[i];
                if (_material)
                {
                    if (_material.HasProperty("_Color"))
                    {
                        SetMaterialColor(_material, red, green, blue);
                    }
                }

            }
            //�滻��������
            for (int i = 0; i < m_WeaponMaterialList.Count; ++i)
            {
                _material = m_WeaponMaterialList[i];
                if (_material)
                {
                    if (_material.HasProperty("_Color"))
                    {
                        SetMaterialColor(_material, red, green, blue);
                    }
                }

            }
        }

        #endregion


        private bool m_bOutLine = false;
        public virtual bool OutLine
        {
            get { return m_bOutLine; }
            set { m_bOutLine = value; }
        }
        private bool m_bShanBai = false;
        private int m_shanbai = 0;
        public void SetShanBai()
        {
            m_bShanBai = true;

        }
        public void UpdateShanBai()
        {

            if (m_bShanBai == true)
            {
                if (m_shanbai == 0)
                {
                    m_BodyMaterialList[0].SetFloat("_whiteColor", 1.0f);
                    m_shanbai = 1;
                    Invoke("CanselShanBai", 0.2f);
                }
            }


        }
        public void CanselShanBai()
        {
            m_bShanBai = false;
            m_BodyMaterialList[0].SetFloat("_whiteColor", 0.0f);
            m_shanbai = 0;
            CancelInvoke("CanselShanBai");
        }
        public void SetOutLine()
        {

           
        }


        public void CancelOutLine()
        {

            return;


        }

        public void SetDissolve()
        {


          
        }


        public void CancelDissolve()
        {



            m_BodyMaterialList[0].shader = m_OldShader;


        }
        #region ��������

        private int m_nStealthLev = 0;
        public virtual int StealthLev
        {
            get { return m_nStealthLev; }
            set { m_nStealthLev = value; }
        }
        public void SetStealthState()
        {
          
        }


        public void CancelStealthState()
        {
          
        }
        #endregion
        #region �ܽ�Ч��
        
        public void UpdateDissolve()
        {
         
        }

        
        public void PlayDissolve(float _Speed, float _delaytime)
        {
            m_bIsPlayDissolve = true;
            m_fPlayDissolveSpeed = _Speed;
            m_fPlayDissolveDelay = _delaytime;
            SetDissolve();
        }

       
        public void PlayUnDissolve(float _Speed, float _delaytime)
        {

            m_bIsPlayUnDissolve = true;
            m_fPlayUnDissolveSpeed = _Speed;
            m_fPlayUnDissolveDelay = _delaytime;
           
            for (int i = 0; i < m_BodyMaterialList.Count; ++i)
            {
                if (null != m_BodyMaterialList[i])
                {
                    if (m_BodyMaterialList[i].HasProperty("_Amount"))
                    {
                        m_BodyMaterialList[i].SetFloat("_Amount", 1.0f);
                    }
                }
            }
          
            for (int i = 0; i < m_WeaponMaterialList.Count; ++i)
            {
                if (null != m_WeaponMaterialList[i])
                {
                    if (m_WeaponMaterialList[i].HasProperty("_Amount"))
                    {
                        m_WeaponMaterialList[i].SetFloat("_Amount", 1.0f);
                    }
                }
            }
            CancelDissolve();
        }

       
        public void ShowDissolveNPC()
        {
            if (m_BodyMaterialList != null)
            {
             
                for (int i = 0; i < m_BodyMaterialList.Count; ++i)
                {
                    if (null != m_BodyMaterialList[i])
                    {
                        if (m_BodyMaterialList[i].HasProperty("_Amount"))
                        {
                            m_BodyMaterialList[i].SetFloat("_Amount", 0.0f);
                        }
                    }
                }
            }

            if (m_WeaponMaterialList != null)
            {
                for (int i = 0; i < m_WeaponMaterialList.Count; ++i)
                {
                    if (null != m_WeaponMaterialList[i])
                    {
                        if (m_WeaponMaterialList[i].HasProperty("_Amount"))
                        {
                            m_WeaponMaterialList[i].SetFloat("_Amount", 0.0f);
                        }
                    }
                }
            }
        }

        #endregion


        #region ��������

        private bool m_bianshen = false;
        public bool BianShen
        {
            get { return m_bianshen; }
            set { m_bianshen = value; }
        }
        private Color oldColor = Color.white;
        private Color oldWeaponColor = Color.white;
        public void SetBianshen(Color col)
        {
           
            
        }


        public void CancelBianshen()
        {
           
        }
        #endregion
        #region 
        #endregion
    }
}