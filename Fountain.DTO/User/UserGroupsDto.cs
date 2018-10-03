﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fountain.DTO.User
{
    public class UserGroupsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserRolesDto> Roles { get; set; }
    }
}