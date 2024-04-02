using Money.Funds;
using Results;

namespace Money.Comparers;

public interface IFundsComparer {
    public Task<Result<FundsComparison>> Compare(IFunds first, IFunds second);
}