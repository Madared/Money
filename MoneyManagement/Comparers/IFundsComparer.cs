using MoneyManagement.Funds;
using Results;

namespace MoneyManagement.Comparers;

public interface IFundsComparer {
    public Task<Result<FundsComparison>> Compare(IFunds first, IFunds second);
}