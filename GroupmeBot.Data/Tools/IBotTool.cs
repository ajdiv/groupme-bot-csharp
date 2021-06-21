﻿using GroupmeBot.Data.Models.GroupMe;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Tools
{
    public interface IBotTool
    {
        Task ProcessMessage(GroupmeRequestModel message);
    }
}
