using AutoMapper;
using Istka_Group4_FoodOrdering_Entity.Services;
using Istka_Group4_FoodOrdering_Entity.UnitOfWorks;
using Istka_Group4_FoodOrdering_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istka_Group4_FoodOrdering_Service.Services
{
   public class InvoiceUserService : IInvoiceUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IAccountService _accountService;

        public InvoiceUserService(IMapper mapper, IUnitOfWork uow, IAccountService accountService)
        {
            _mapper = mapper;
            _uow = uow;
            _accountService = accountService;
        }

        public void LoadUser(InvoiceViewModel model)
        {

        }

    }
}
