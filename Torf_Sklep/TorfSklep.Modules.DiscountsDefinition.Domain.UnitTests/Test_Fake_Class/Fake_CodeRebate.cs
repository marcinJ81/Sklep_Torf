using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorfSklep.Modules.DiscountsDefinition.Domain.Interfaces;
using TorfSklep.Modules.RebatesDefinitions.Repository.RebateCode;

namespace TorfSklep.Modules.DiscountsDefinition.Domain.UnitTests.Test_Fake_Class
{
    public class Fake_CodeRebate : ICodeRebateFunctions
    {
        public List<RebateCodeTable> GetListOfCode(string category)
        {
            List<RebateCodeTable> result = GetListOfCode();
            return result;
        }

        public List<RebateCodeTable> GetListOfCode()
        {
            List<RebateCodeTable> codeRebate = new List<RebateCodeTable>
            {
                new RebateCodeTable
                {
                    RebateC_id = 1,
                    Rebate_id = 1,
                    RebateC_value = "test1",
                    RebateC_Category = "wiosna"
                },
                new RebateCodeTable
                {
                    RebateC_id = 2,
                    Rebate_id = 2,
                    RebateC_value = "test2",
                    RebateC_Category = "zima"
                },
                new RebateCodeTable
                {
                    RebateC_id = 3,
                    Rebate_id = 3,
                    RebateC_value = "",
                    RebateC_Category = "stały rabat"
                }
            };
            return codeRebate;
        }

        public RebateCodeTable GetOneRebateCode(int rebateC_id)
        {
            throw new NotImplementedException();
        }

        public bool JoinDefinitionAndCode(int rebate_id)
        {
            var result = GetListOfCode();
            if (!result.Any(x => x.Rebate_id == rebate_id))
                return false;
            return true;
        }

        public bool JoinDefinitionAndCode(int rebate_id, string codeName)
        {
            var result = GetListOfCode();
            if (result.Any(x => x.Rebate_id == rebate_id))
            {
                //add codeName to code rebate
                bool existName = result.Any(x => x.Rebate_id == rebate_id && x.RebateC_Category == codeName);
                return existName;
            }
            else
            {
                return false;
            }
        }
    }
}
