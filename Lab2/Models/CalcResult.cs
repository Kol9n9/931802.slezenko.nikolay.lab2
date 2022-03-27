namespace Lab2.Models
{
    /// <summary>
    /// Результат вычисления
    /// </summary>
    public class CalcResult
    {
        public int FirstValue { get; set; }
        public int SecondValue { get; set; }
        public string Name { get; private set; }
        public string Operation { get; set; }
        public string Result { get; private set; }
        public CalcResult()
        {
            Name = "";
            Result = "";
        }
        public CalcResult(int firstValue, int secondValue, string operation)
        {
            FirstValue = firstValue;
            SecondValue = secondValue;
            Operation = operation;
            Calc();
        } 

        public string Print()
        {
            if(Result == "") Calc();
            return $"{FirstValue} {Operation} {SecondValue} = {Result}";
        }

        private void Calc()
        {
            switch (Operation)
            {
                case "+":
                    {
                        Name = "Add";
                        Result = (FirstValue + SecondValue).ToString();
                        break;
                    }
                case "-":
                    {
                        Name = "Sub";
                        Result = (FirstValue - SecondValue).ToString();
                        break;
                    }
                case "*":
                    {
                        Name = "Mult";
                        Result = (FirstValue * SecondValue).ToString();
                        break;
                    }
                case "/":
                    {
                        Name = "Div";
                        if (SecondValue == 0)
                        {
                            Result = "Attempt to divide by zero";
                        }
                        else
                        {
                            Result = (FirstValue / SecondValue).ToString();
                        }
                        break;
                    }
            }
        }
    }
}
