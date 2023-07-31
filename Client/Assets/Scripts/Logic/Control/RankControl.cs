using Base;

public class send_get_rank_data_c2s: base_proto
{
    public int userId;
}

public class on_get_rank_data_s2c: base_proto
{
    public int userId;
    public int rankIndex;
}


public class RankControl
{
    public static string module = "rank";
    public static void send_get_rank_data_c2s(int userId)
    {
        send_get_rank_data_c2s msg = new send_get_rank_data_c2s();
        msg.action = msg.GetType().Name;
        msg.userId = userId;
        NetManager.Instance.Send<send_get_rank_data_c2s, on_get_rank_data_s2c>(module, msg, on_get_rank_data_s2c);
    }
    public static void on_get_rank_data_s2c(on_get_rank_data_s2c receiveData)
    {
        UDebug.Log(receiveData.userId.ToString());
        UDebug.Log(receiveData.rankIndex.ToString());
    }
}
