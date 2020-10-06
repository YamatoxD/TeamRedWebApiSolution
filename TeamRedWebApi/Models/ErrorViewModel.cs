using System;

namespace TeamRedProject.Models
{
#pragma warning disable CS1591
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
#pragma warning restore CS1591
}
