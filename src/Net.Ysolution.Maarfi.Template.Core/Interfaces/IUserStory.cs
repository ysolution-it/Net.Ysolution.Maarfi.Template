using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;

namespace Net.Ysolution.Maarfi.Template.Core.Interfaces;

    public  interface IUserStory<T , R>
    {
        Task<Result<R>> Execute(T requestDTO);
    }

