using Pension.Domain.Models;
using System;

namespace Pension.MVC.Models
{
    public class ErrorViewModel : UserModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
