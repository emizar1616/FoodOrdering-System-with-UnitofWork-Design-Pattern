using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istka_Group4_FoodOrdering_Entity.ViewModels
{
    public class UsersInOrOutViewModel
    {
        public RoleViewModel Role { get; set; }
        public List<UserViewModel> UsersInRole { get; set; }
        public List<UserViewModel> UsersOutRole { get; set; }
    }
}
