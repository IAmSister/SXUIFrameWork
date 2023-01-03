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
        //一个一个的消息号  类似于protocal 中的一个一个的类  承载着需要的数据
        //去new不同的类
        PacketDistributed packet = null;
        if (null != packet)
        {
            packet.packetID = packetID;
        }
        return packet;
    }
    //发送消息
    public void SendPacket()
    {
        //网络逻辑开始执行
        //    单例      发送
      NetWorkLogic.GetMe().SendPacket(this); //这个this就相当于每个类
    }

    //解析
    public PacketDistributed ParseFrom(byte[] data, int nLen)
    {
     //把数据放到outputstream里面
        return null;
    }

    public abstract int SerializedSize();
    public abstract void WriteTo(CodedOutputStream data);
    public abstract PacketDistributed MergeFrom(CodedInputStream input, PacketDistributed _Inst);
    public abstract bool IsInitialized();

    public MessageID GetPacketID() { return packetID; }
    protected MessageID packetID;
}
