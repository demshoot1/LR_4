using System.Numerics;
using System.Collections.Generic;
using Task_1;
using System.ComponentModel.Design;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите имя и процентную ставку банка");
        String name = Console.ReadLine();
        decimal insertrate = decimal.Parse(Console.ReadLine());
        Bank bank = Bank.GetInstance(name, insertrate);
        bool flag = true;
        while (flag) {
            Console.WriteLine("Выберите необходимое действие: \n" +
                "0 - завершить программу \n" +
                "1 - внести информацию о новом влкаде\n" +
                "2 - провести операции над вкладами");
            int option =  int.Parse(Console.ReadLine());
            switch (option)
            {
                case 0:
                    flag = false;
                    break;

                case 1:
                    Console.WriteLine("Введите размер вклада: ");
                    decimal insize = decimal.Parse(Console.ReadLine());
                    Deposit deposit = new Deposit();
                    deposit.SetSize(insize);
                    bank.deposits.Add(deposit);
                    bank.SetAmount(bank.GetAmount() + 1);
                    break;

                case 2:
                    Console.WriteLine("Выберите вклад, для проведения операции");
                    int depositIndex = int.Parse(Console.ReadLine());
                    Deposit chosenDeposit = bank.deposits[depositIndex];
                    Console.WriteLine("Выберите необходимую операцию: \n" +
                        "1 - увеличть вклад \n" +
                        "2 - уменьшить вклад \n" +
                        "3 - вывести информацию об общей выплате по процентам");
                    int secondOption = int.Parse(Console.ReadLine());

                    switch (secondOption)
                    {
                        case 1:
                            Console.WriteLine("На сколько увеличить вклад?");
                            int increment = int.Parse(Console.ReadLine());
                            chosenDeposit.IncreaseSize(increment);
                            break;

                        case 2:
                            Console.WriteLine("На сколько уменьшить вклад?");
                            int decrement = int.Parse(Console.ReadLine());
                            chosenDeposit.DecreaseSize(decrement);
                            break;

                        case 3:
                            Console.WriteLine("За сколько месяцев посчитать процентную ставку?");
                            int monthAmount = int.Parse(Console.ReadLine());
                            Console.WriteLine("Общая выплата по процентам данного вклада составит: " +
                                bank.CalculateInterestPayment(chosenDeposit, monthAmount));
                            break;

                        default:
                            Console.WriteLine("Некорректный ввод");
                            break;

                    }
                    break;

                default:
                    Console.WriteLine("Некорректный ввод");
                    break;

            }
        }
    }
}