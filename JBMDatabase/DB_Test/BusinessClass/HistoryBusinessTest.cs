using JBMDatabase.Business;
using JBMDatabase.UnitOfWork;

namespace DB_Test.BusinessClass
{
    public class HistoryBusinessTest : HistoryBusiness
    {
        public HistoryBusinessTest(IUoW uow) : base(uow)
        {
        }
    }
}
