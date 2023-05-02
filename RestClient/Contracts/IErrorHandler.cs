using System;

namespace RestClient.Contracts
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}
