﻿using GameServer.CsScript.Base;
using GameServer.CsScript.Com;
using GameServer.CsScript.JsonProtocol;
using GameServer.Script.CsScript.Action;
using GameServer.Script.Model.Config;
using GameServer.Script.Model.DataModel;
using System;
using System.Collections.Generic;
using ZyGames.Framework.Cache.Generic;
using ZyGames.Framework.Game.Com.Rank;
using ZyGames.Framework.Game.Contract;
using ZyGames.Framework.Game.Service;

namespace GameServer.CsScript.Action
{

    /// <summary>
    /// 1401_名人榜前50名
    /// </summary>
    public class Action1406 : BaseAction
    {
        public List<JPRankUserData> receipt;
        private Random random = new Random();

        public Action1406(ActionGetter actionGetter)
            : base(ActionIDDefine.Cst_Action1406, actionGetter)
        {

        }

        protected override string BuildJsonPack()
        {
            if (receipt != null)
            {
                body = receipt;
            }
            else
            {
                ErrorCode = ActionIDDefine.Cst_Action1406;
            }
            return base.BuildJsonPack();
        }

        public override bool GetUrlElement()
        {
            return true;
        }

        public override bool TakeAction()
        {
            receipt = new List<JPRankUserData>();
            var ranking = RankingFactory.Get<UserRank>(CombatRanking.RankingKey);


            int pagecout;
            var list = ranking.GetRange(0, 50, out pagecout);
            foreach (var data in list)
            {
                GameUser user = UserHelper.FindUser(data.UserID);
                if (user == null)
                    continue;
                JPRankUserData jpdata = new JPRankUserData()
                {
                    UserId = user.UserID,
                    NickName = user.NickName,
                    LooksId = user.LooksId,
                    RankId = user.CombatData.RankID,
                    UserLv = user.UserLv,
                    Exp = user.TotalExp,
                    FightingValue = user.FightingValue,
                    VipLv = user.VipLv
                };
                GameSession session = GameSession.Get(data.UserID);
                if (session != null && session.Connected)
                    jpdata.IsOnline = true;

                receipt.Add(jpdata);
            }
            return true;
        }
        
    }
}