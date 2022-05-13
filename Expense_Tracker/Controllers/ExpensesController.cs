using Expense_Tracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expense_Tracker.Controllers
{
    public class ExpensesController : Controller
    {
        public readonly DatabaseContext _Db;
        public ExpensesController(DatabaseContext db)
        {
            _Db = db;
        }
        public IEnumerable<Expence> results { get; set; }
        [HttpPost]
        public IActionResult Index(DateTime? startDate, DateTime? endDate)
        {
            var results = (from a in _Db.Expenses
                           join b in _Db.Categories
                           on a.CategoryId equals b.CategoryId into ExpCat
                           from d in ExpCat.DefaultIfEmpty()

                           select new Expence
                           {
                               Id = a.Id,
                               ExpenseDate = a.ExpenseDate,
                               Amount = a.Amount,
                               CategoryName = d.CategoryName,
                               CategoryId = d.CategoryId
                           }).Where(x => x.ExpenseDate >= startDate && x.ExpenseDate <= endDate).ToList();
            //expList.OrderBy(a=> a.Id).Skip((currentPage - 1) * maxRows).Take()
            return View(results);
        }
        public IActionResult Index()
        {
            var expList = from a in _Db.Expenses
                          join b in _Db.Categories
                          on a.CategoryId equals b.CategoryId
                          into ExpCat
                          from d in ExpCat.DefaultIfEmpty()
                          
                          select new Expence 
                          {
                              Id = a.Id,
                              ExpenseDate = a.ExpenseDate,
                              Amount = a.Amount,
                              CategoryName = d.CategoryName,
                              CategoryId = d.CategoryId
                          };
            //expList.OrderBy(a=> a.Id).Skip((currentPage - 1) * maxRows).Take()
            return View(expList);

            
        }
       
        //public IActionResult Create(Expence expenceObj)
        //{
        //    CategoryDropdownlistLoad();
        //    return View(expenceObj);
        //}
        public async Task<IActionResult> Create(int id)
        {
            if (id == 0)
            {
                CategoryDropdownlistLoad();
                return View();
            }
            CategoryDropdownlistLoad();
            var ExpensesData = await _Db.Expenses.FindAsync(id);
            if (ExpensesData == null)
            {
                return NotFound();
            }
            ExpensesViewModel vmNew = new ExpensesViewModel();
            vmNew.Id = ExpensesData.Id;
            vmNew.CategoryId = ExpensesData.CategoryId;
            vmNew.CategoryName = ExpensesData.CategoryName;
            vmNew.ExpenseDate = ExpensesData.ExpenseDate;
            vmNew.Amount = ExpensesData.Amount;            
            return View(vmNew);            

        }

        [HttpPost]
        public async Task<IActionResult> AddExpense(ExpensesViewModel expenceObj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Expence newEx = new Expence();
                    if (expenceObj.Id == null)
                    {                        
                        newEx.ExpenseDate = (DateTime) expenceObj.ExpenseDate;
                        newEx.CategoryId = expenceObj.CategoryId;
                        newEx.Amount = expenceObj.Amount;
                    }
                    else
                    {
                        newEx.Id = (int) expenceObj.Id;
                        newEx.ExpenseDate = (DateTime) expenceObj.ExpenseDate;
                        newEx.CategoryId = expenceObj.CategoryId;
                        newEx.Amount = expenceObj.Amount;
                    }
                   
                    if (newEx.Id == 0)
                    {
                        _Db.Expenses.Add(newEx);
                        await _Db.SaveChangesAsync();
                    } else
                    {
                        _Db.Entry(newEx).State = EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }
                   
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Create");
              
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var ExpenseRecord = await _Db.Expenses.FindAsync(id);
                if (ExpenseRecord != null)
                {
                    _Db.Expenses.Remove(ExpenseRecord);
                    await _Db.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
               return RedirectToAction("Index");
                
            }
        }
        private void CategoryDropdownlistLoad()
        {
            try
            {
                List<ExpenceCategory> catList = new List<ExpenceCategory>();
                catList = _Db.Categories.ToList();
                catList.Insert(0, new ExpenceCategory { CategoryId = 0, CategoryName = "Please Select" });
                ViewBag.CategoryList = catList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
