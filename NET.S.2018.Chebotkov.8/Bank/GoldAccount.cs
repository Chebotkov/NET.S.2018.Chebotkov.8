using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class GoldAccount : Account
    {
        private int percentsForSum;
        private int percentsForPrivilegies;

        public GoldAccount(PersonalInfo personalInfo) : base(personalInfo)
        {

        }

        /// <summary>
        /// Gets percents for adding/withdrawing.
        /// </summary>
        public override int PercentsForSum
        {
            get
            {
                return percentsForSum;
            }

            set
            {
                percentsForSum = value < 0 ? 1 : value;
            }
        }

        /// <summary>
        /// Gets percents for privilegies.
        /// </summary>
        public override int PercentsForPrivilegies
        {
            get
            {
                return percentsForPrivilegies;
            }

            set
            {
                percentsForPrivilegies = value < 0 ? 1 : value;
            }
        }

        public override bool IsValidBalance()
        {
            throw new NotImplementedException();
        }
    }
}
