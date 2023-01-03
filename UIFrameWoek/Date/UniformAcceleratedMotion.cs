using Games.LogicObj;
using UnityEngine;
using System.Collections;
using Games.Scene;

public class UniformAcceleratedMotion : MonoBehaviour
{

    public Vector3 m_OriginPosition = new Vector3(0, 0, 0);
    public Vector3 m_Velocity = new Vector3(0, 0, 0);
    public Vector3 m_Acceleration = new Vector3(0, 0, 0);
    private float m_StartTime = 0;
    private float m_MotionTime = 0;

    private bool m_bGoing = false;
    public bool Going
    {
        get { return m_bGoing; }

    }
    private Vector3 m_OriginVelocity = new Vector3(0, 0, 0);

    private bool m_bObjMove = false;
    private Transform m_transform;
    // Use this for initialization
    void Start()
    {
        m_transform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_bGoing)
        {
            if (m_bObjMove)
            {
                ObjMovePlay();
            }
            else
            {
                Play();
            }

        }
    }

    public void Init(Vector3 vecVelocity, Vector3 vecAcceleration, float fMotionTime, bool isObj = false)
    {
        m_Velocity = vecVelocity;
        m_OriginVelocity = vecVelocity;
        m_Acceleration = vecAcceleration;
        m_MotionTime = fMotionTime;
        m_bObjMove = isObj;
        if (isObj)
        {
            Obj_Character _objChar = gameObject.GetComponent<Obj_Character>();
            if (_objChar)
            {
                if (_objChar.NavAgent != null && _objChar.NavAgent.enabled)
                {
                    _objChar.NavAgent.enabled = false;//禁用寻路代理
                }
            }
        }
    }

    public void Go()
    {
        m_bGoing = true;
        m_StartTime = Time.fixedTime;
    }

    void Play()
    {
        if (Time.fixedTime - m_StartTime <= m_MotionTime)
        {
            gameObject.transform.localPosition += m_Velocity * Time.deltaTime;
            m_Velocity += m_Acceleration * Time.deltaTime;
        }
        else
        {
            m_bGoing = false;
            m_StartTime = 0;
            m_Velocity = m_OriginVelocity;
        }
    }

    void ObjMovePlay()
    {
        if (null == m_transform)
            return;

        Obj_Character _objChar = this.gameObject.GetComponent<Obj_Character>();
        if (_objChar)
        {
            Vector3 _selfVector3 = new Vector3(m_transform.localPosition.x, 0, m_transform.localPosition.z);
            Vector3 _newVector3 = ActiveScene.GetTerrainPosition(_selfVector3);
            if (Time.fixedTime - m_StartTime <= m_MotionTime)
            {
                m_transform.localPosition += (m_Velocity * Time.deltaTime);
                _selfVector3 = new Vector3(m_transform.localPosition.x, 0, m_transform.localPosition.z);
                _newVector3 = ActiveScene.GetTerrainPosition(_selfVector3);
                if (Time.fixedTime - m_StartTime >= m_MotionTime / 2 && m_transform.localPosition.y <= _newVector3.y)
                {
                    m_transform.localPosition = _newVector3;
                    m_bGoing = false;
                    m_StartTime = 0;
                    m_Velocity = m_OriginVelocity;
                }
                m_Velocity += (m_Acceleration * Time.deltaTime);
            }
            else
            {
                m_bGoing = false;
                m_transform.localPosition = _newVector3;
                m_StartTime = 0;
                m_Velocity = m_OriginVelocity;
            }
        }

    }
}
