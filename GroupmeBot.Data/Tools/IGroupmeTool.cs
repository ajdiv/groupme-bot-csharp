﻿using GroupmeBot.Data.Models.GroupMe;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Tools
{
    public interface IGroupmeTool
    {
        public Task<IList<GroupmeMessageModel>> GetMessages(int limit, string beforeId, string afterId);

        /// <returns>
        /// Item 1: Result Text - Item 2: Loci - Item 3: UserIds
        /// </returns>
        public Task<(string, List<int[]>, List<string>)> TagAllMembersInGroup();
    }
}