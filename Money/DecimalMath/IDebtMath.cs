using Results;

namespace Money.DecimalMath;

public interface IDebtMath {
    Task<Result<Debt>> Plus(Debt first, Debt second);
}