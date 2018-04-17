using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc01
{
    /// <summary>
    /// appsettings映射实体类
    /// </summary>
    public class AppSettingsModel
    {
        public int BranchId { get; set; }

        public string BranchName { get; set; }

        public ICollection<UserAccount> UserAccounts { get; set; }
    }

    public class UserAccount
    {
        public int UserId { get; set; }

        public string UserName { get; set; }
    }
}
