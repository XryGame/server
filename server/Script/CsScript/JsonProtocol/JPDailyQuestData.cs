﻿using GameServer.Script.Model.Enum;

namespace GameServer.CsScript.JsonProtocol
{
    public class JPDailyQuestData
    {

        public TaskType ID { get; set; }


        public bool IsFinish { get; set; }


        public int RefreshCount { get; set; }
        

        public int FinishCount { get; set; }

        public int Count { get; set; }
    }
}
