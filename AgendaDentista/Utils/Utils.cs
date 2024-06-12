public class Utils {
	public static int GetAge(DateTime birthDate) {
		return (new DateTime(1, 1, 1) + (DateTime.Now - birthDate)).Year - 1;
	}

	public static bool ValidCpf(string cpf) {
		int[] digits = Array.ConvertAll(cpf.ToCharArray(), character => (int)char.GetNumericValue(character));

		// If all digits are equal
		if (digits.Sum() / digits.Length == digits[0]) {
			return false;
		}

		int firstRemainder = (digits[0] * 10 + digits[1] * 9 + digits[2] * 8 + digits[3] * 7 + digits[4] * 6 + digits[5] * 5 + digits[6] * 4 + digits[7] * 3 + digits[8] * 2) % 11;
		int trueFirstDigit = (firstRemainder == 0 || firstRemainder == 1) ? 0 : (11 - firstRemainder);

		if (trueFirstDigit != digits[9]) {
			return false;
		}

		int secondRemainder = (digits[0] * 11 + digits[1] * 10 + digits[2] * 9 + digits[3] * 8 + digits[4] * 7 + digits[5] * 6 + digits[6] * 5 + digits[7] * 4 + digits[8] * 3 + digits[9] * 2) % 11;
		int trueSecondDigit = (secondRemainder == 0 || secondRemainder == 1) ? 0 : (11 - secondRemainder);

		if (trueSecondDigit != digits[10]) {
			return false;
		}

		return true;
	}
}
