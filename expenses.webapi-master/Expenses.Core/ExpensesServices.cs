using Expenses.Core.DTO;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace Expenses.Core
{
    public class ExpensesServices : IExpensesServices
    {
        private readonly DB.AppDbContext _context;
        private readonly DB.User _user;

        public ExpensesServices(DB.AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _user = _context.Users
                .First(u => u.Username == httpContextAccessor.HttpContext.User.Identity.Name);
        }

        public Expense CreateExpense(DB.Expense expense)
        {
            _user.Balance = (_user.Balance - expense.Amount);
            expense.User = _user;
            _context.Add(expense);
            _context.SaveChanges();

            return (Expense)expense;
        }

        public void DeleteExpense(Expense expense)
        {
            var dbExpense = _context.Expenses.First(e => e.User.Id == _user.Id && e.Id == expense.Id);
            _context.Remove(dbExpense);
            _context.SaveChanges();
        }

        public Expense EditExpense(Expense expense)
        {
            var dbExpense = _context.Expenses
                 .Where(e => e.User.Id == _user.Id && e.Id == expense.Id)
                 .First();
            dbExpense.Description = expense.Description;
            dbExpense.Amount = expense.Amount;
            _context.SaveChanges();

            return expense;
        }

        public Expense GetExpense(int id) =>
            _context.Expenses
                .Where(e => e.User.Id == _user.Id && e.Id == id)
                .Select(e => (Expense)e)
                .First();

        public List<Expense> GetExpenses() =>
            _context.Expenses
                .Where(e => e.User.Id == _user.Id)
                .Select(e => (Expense)e)
                .ToList();

        public Expense MakeDeposit(DB.Expense expense)
        {
            _user.Balance = (_user.Balance + expense.Amount);
            expense.User = _user;
            _context.Add(expense);
            _context.SaveChanges();

            return (Expense)expense;
        }

        public Expense MakeFundsTransfer( DB.Expense expense)
        {
            var toAccount = _context.Users
                .First(u => u.AccountNumberGenerated == expense.ToAccount);

            _user.Balance = (_user.Balance - expense.Amount);
            toAccount.Balance = (toAccount.Balance + expense.Amount);
            expense.User = _user;
            _context.Add(expense);
            _context.SaveChanges();

            return (Expense)expense;
        }

        public Expense MakeWithdrawal(DB.Expense expense)
        {
            _user.Balance = (_user.Balance - expense.Amount);
            expense.User = _user;
            _context.Add(expense);
            _context.SaveChanges();

            return (Expense)expense;
        }

        //public Expense MakeDeposit(int Amount)
        //{

        //    _user.Balance = _user.Balance + Amount;
        //    var expense = new Expense();
        //    expense.Description = "Deposit";
        //    _context.SaveChanges();
        //    return expense;
        //}

        //public Expense MakeFundsTransfer(string ToAccount, int Amount)
        //{
        //    var userFromAccount = _user;
        //    var userToAccount = _context.Users.First(u => u.AccountNumberGenerated == ToAccount);
        //    userFromAccount.Balance = userFromAccount.Balance - Amount;
        //    userToAccount.Balance = userFromAccount.Balance + Amount;
        //    var expense = new Expense();
        //    expense.Description = "FundsTransfer";
        //    _context.SaveChanges();
        //    return expense;
        //}

        //public Expense MakeWithdrawal(int Amount)
        //{

        //    _user.Balance = _user.Balance - Amount;
        //    var expense = new Expense();
        //    expense.Description = "Withdraw";
        //    _context.SaveChanges();
        //    return expense;
        //}
    }
}
