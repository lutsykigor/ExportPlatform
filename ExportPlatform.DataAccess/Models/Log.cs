using System;

namespace ExportPlatform.DataAccess
{
    public class Log
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public string Email { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }
    }
}
