using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application
{
    public class Constants
    {
        /// <summary>
        /// TODO: We need a centralized way of providing the current logged in user 
        /// such that we can populate some of the fields in SQL tables.
        /// This constant needs to be transformed something robust.
        /// A Mediatr Pipeline or Pre/Post Processor a choice?
        /// </summary>
        public const string CurrentUser = "Test User";
    }
}
