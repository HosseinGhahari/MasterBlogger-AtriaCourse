﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.Serivce
{
    public interface IArticleCategoryValidationService
    {
        void TitleExistCheck(string title);
    }
}
