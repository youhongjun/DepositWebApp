using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MockDeposits.Repositories;

namespace DepositWebApp.Controllers
{
    public class DepositController : Controller
    {
        IDepositRepository depositRepository = null;

        public DepositController(IDepositRepository repository)
        {
            depositRepository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoadData()
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                var data = depositRepository.GetDeposits().ToList();
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    if(sortColumnDirection == "asc")
                    {
                        switch (sortColumn)
                        {
                            case "StartDate":
                                data = data.OrderBy(d => d.StartDate).ToList();
                                break;
                            case "EndDate":
                                data = data.OrderBy(d => d.EndDate).ToList();
                                break;
                            case "Principal":
                                data = data.OrderBy(d => d.Principal).ToList();
                                break;
                            case "InterestRate":
                                data = data.OrderBy(d => d.InterestRate).ToList();
                                break;
                            case "TermInYears":
                                data = data.OrderBy(d => d.TermInYears).ToList();
                                break;
                            case "MaturityAmount":
                                data = data.OrderBy(d => d.MaturityAmount).ToList();
                                break;
                        }
                    }
                    else
                    {
                        switch (sortColumn)
                        {
                            case "StartDate":
                                data = data.OrderByDescending(d => d.StartDate).ToList();
                                break;
                            case "EndDate":
                                data = data.OrderByDescending(d => d.EndDate).ToList();
                                break;
                            case "Principal":
                                data = data.OrderByDescending(d => d.Principal).ToList();
                                break;
                            case "InterestRate":
                                data = data.OrderByDescending(d => d.InterestRate).ToList();
                                break;
                            case "TermInYears":
                                data = data.OrderByDescending(d => d.TermInYears).ToList();
                                break;
                            case "MaturityAmount":
                                data = data.OrderByDescending(d => d.MaturityAmount).ToList();
                                break;
                        }
                    }
                }

                recordsTotal = data.Count();
                var totalMaturityAmount = data.Sum(d => d.MaturityAmount);
                var res = data.Skip(skip).Take(pageSize).ToList();
                var json = Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = res, totalMaturityAmount = totalMaturityAmount });
                return json;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
