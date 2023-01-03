//This code create by CodeEngine

using System.IO;
using System;
#if UNITY_WP8
 using UnityPortSocket; 
#else
using System.Net.Sockets;
#endif
using Google.ProtocolBuffers;

public abstract class PacketDistributed
{
    public static PacketDistributed CreatePacket(MessageID packetID)
    {
        //һ��һ������Ϣ��  ������protocal �е�һ��һ������  ��������Ҫ������
        //ȥnew��ͬ����
        PacketDistributed packet = null;
        if (null != packet)
        {
            packet.packetID = packetID;
        }
        return packet;
    }
    //������Ϣ
    public void SendPacket()
    {
        //�����߼���ʼִ��
        //    ����      ����
      NetWorkLogic.GetMe().SendPacket(this); //���this���൱��ÿ����
    }

    //����
    public PacketDistributed ParseFrom(byte[] data, int nLen)
    {
     //�����ݷŵ�outputstream����
        return null;
    }

    public abstract int SerializedSize();
    public abstract void WriteTo(CodedOutputStream data);
    public abstract PacketDistributed MergeFrom(CodedInputStream input, PacketDistributed _Inst);
    public abstract bool IsInitialized();

    public MessageID GetPacketID() { return packetID; }
    protected MessageID packetID;
}
