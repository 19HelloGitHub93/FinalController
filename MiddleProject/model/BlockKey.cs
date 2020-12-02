namespace MiddleProject.model
{
    public class BlockKey
    {
        /// <summary>
        /// 屏蔽关键词打印
        /// </summary>
        public static readonly OrderCode[] keyWord =
        {
            //OrderCode.HeartBeat,
            //OrderCode.ClientRquest,
            //OrderCode.OffLine
        };

        public static bool IsBlock(Data data)
        {
            foreach (var item in keyWord)
            {
                if (data.code==item)
                    return true;
            }
            return false;
        }
    }
}