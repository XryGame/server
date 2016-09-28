﻿using GameServer.Script.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.CsScript.JsonProtocol
{
    public class JPRequestTaskData
    {
        public SubjectType SubjectT { get; set; }

        public SceneType SceneId { get; set; }

        public int SubjectId { get; set; }

        public long StartTime { get; set; }

        public int Count { get; set; }

    }
}
