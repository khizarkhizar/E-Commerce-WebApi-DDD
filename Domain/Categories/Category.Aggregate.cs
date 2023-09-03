using Domain.Base;  
using System;
using System.Linq;

namespace Domain.Categories
{
    public partial class CtgrNme : IAggregateRoot
    {
        public CtgrNme(string CtgrName ,string SubCtgr)
        {
            

            this.Update(
                 CtgrName, SubCtgr
            );
        }

        public void Update(string CtgrName, string SubCtgr)
        {
            this.CtgrName = CtgrName;
            this.SubCtgr = SubCtgr;
       
        }

       

        
    }
}