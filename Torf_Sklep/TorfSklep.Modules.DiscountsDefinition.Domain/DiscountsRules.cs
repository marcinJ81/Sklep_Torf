using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.DiscountsDefinition.Domain.SimpleClass;

namespace TorfSklep.Modules.DiscountsDefinition.Domain
{
   public class DiscountsRules
    {
        private readonly ICreateDefinitionDiscount definitionDiscount;

        public DiscountsRules(ICreateDefinitionDiscount definitionDiscount)
        {
            this.definitionDiscount = definitionDiscount ?? throw new ArgumentNullException(nameof(definitionDiscount));
        }

        public bool SetDiscountsRules()
        {
            throw new Exception();
        }

        public bool ChooseDiscountsTypes(int discount_id)
        {
            throw new Exception();
        }

    }
}
