﻿using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.DAO.Interface
{
    public interface IDAOGroupUser
    {
        IList<Group> GetGroupByUser(int idUser);
    }
}
