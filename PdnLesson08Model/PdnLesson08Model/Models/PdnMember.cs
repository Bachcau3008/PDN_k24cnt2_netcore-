using System.ComponentModel;

namespace PdnLesson08Model.Models
{
    public class PdnMember
    {
        public string PdnMemberId { get; set; }
        public string PdnUserName { get; set; }
        public string PdnPassword { get; set; }

        [DisplayName ("Họ và tên")]   
        public string PdnFullName { get; set; }
        public string PdnEmail { get; set; }

    }
}
