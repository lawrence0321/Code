using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface
{
    /// <summary>
    /// 實體物件，EntityFramework的基底物件
    /// </summary>
    public interface IEntity
    {
    }

    /// <summary>
    /// 設定IEntity有對應到的IViewModel。
    /// </summary>
    /// <typeparam name="T">要被對應到的Type</typeparam>

    public interface IMapperTo<T> : IEntity where T : IDTO
    {
    }
}
