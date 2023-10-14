﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Context;
using Domain.Entities;
using Domain.Repository;

namespace WebApp.Pages.StoreServices
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<StoreService> StoreService { get;set; }

        public async Task OnGetAsync()
        {
            StoreService = await _unitOfWork.StoreService.Get().AsQueryable()
                .Include(s => s.LaundryStore)
                .Include(s => s.Service).ToListAsync();
        }
    }
}
