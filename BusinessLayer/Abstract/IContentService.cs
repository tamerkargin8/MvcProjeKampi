﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public  interface IContentService
    {
        List<Content> GetContentList();
        List<Content> GetListByHeadingID(int id);
        void ContentAdd(Content content);
        void ContentDelete(Content content);
        void ContentUpdate(Content content);
        Content GetByID(int id);
    }
}
