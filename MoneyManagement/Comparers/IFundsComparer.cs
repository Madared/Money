using MoneyManagement.Funds;
using ResultAndOption.Results;

namespace MoneyManagement.Comparers;

public interface IFundsComparer {
    public Task<Result<FundsComparison>> Compare(IFunds first, IFunds second);
}