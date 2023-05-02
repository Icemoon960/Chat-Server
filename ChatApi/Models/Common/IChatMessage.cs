

using System;

namespace ChatApi.Models.Common
{
    public interface IChatMessage
    {
        DateTime LastEdited { get; set; }
        string MessageText { get; set; }
    }
}
